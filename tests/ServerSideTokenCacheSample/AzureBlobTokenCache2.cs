using System;
using System.Threading;

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ServerSideTokenCacheSample
{
    class AzureBlobTokenCache2: TokenCache
    {
        private const string CloudStorageAccountSetting = "UseDevelopmentStorage=true";
        private const string TokenCacheContainerName = "adal";
        private readonly CloudBlobContainer container;

        private readonly Random rand = new Random();

        private string leaseId = null;
        
        static AzureBlobTokenCache2()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudStorageAccountSetting);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(TokenCacheContainerName);
            container.DeleteIfExists();
        }

        public AzureBlobTokenCache2()
        {
            this.AfterAccess = CustomTokenCache_AfterAccess;
            this.BeforeAccess = CustomTokenCache_BeforeAccess;

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudStorageAccountSetting);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            this.container = blobClient.GetContainerReference(TokenCacheContainerName);
            this.container.CreateIfNotExists();
        }

        void CustomTokenCache_BeforeAccess(TokenCacheAccessArgs args)
        {
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(args.Resource);
            if (blockBlob.Exists())            
            {
                byte[] blob = new byte[blockBlob.Properties.Length];

                AcquireLease(blockBlob);
                blockBlob.DownloadToByteArray(blob, 0, AccessCondition.GenerateLeaseCondition(leaseId));
                this.Deserialize(blob);
            }
        }

        void CustomTokenCache_AfterAccess(TokenCacheAccessArgs args)
        {
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(args.Resource);
            if (this.HasStateChanged)
            {
                byte[] blob = this.Serialize();
                AcquireLease(blockBlob);
                blockBlob.UploadFromByteArray(blob, 0, blob.Length, (leaseId != null) ? AccessCondition.GenerateLeaseCondition(leaseId) : null);
                this.HasStateChanged = false;
            }

            ReleaseLease(blockBlob);
        }

        void AcquireLease(CloudBlockBlob blockBlob)
        {
            if (leaseId != null || !blockBlob.Exists())
                return;

            int retryCount = 0;
            const int MaxRetryCount = 30;
            bool acquired = false;

            do
            {
                try
                {
                    leaseId = Guid.NewGuid().ToString();
                    blockBlob.AcquireLease(TimeSpan.FromSeconds(15), leaseId);  // 15 seconds is the minimum
                    acquired = true;
                }
                catch (StorageException ex)
                {
                    if (ex.RequestInformation.HttpStatusCode == 409)
                    {
                        retryCount++;
                        Thread.Sleep(rand.Next(50, 300));
                    }
                }
            } while (!acquired && retryCount < MaxRetryCount);

            if (!acquired) 
                throw new TimeoutException("Failed to acquire exclusive access to persistent token cache");
        }

        void ReleaseLease(CloudBlockBlob blockBlob)
        {
            if (leaseId != null)
            {
                blockBlob.ReleaseLease(AccessCondition.GenerateLeaseCondition(leaseId));
                leaseId = null;
            }            
        }
    }
}
