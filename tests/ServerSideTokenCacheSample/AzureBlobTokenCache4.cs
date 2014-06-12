using System;
using System.Threading;

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ServerSideTokenCacheSample
{
    class AzureBlobTokenCache4 : TokenCache
    {
        private const string CloudStorageAccountSetting = "UseDevelopmentStorage=true";
        private const string TokenCacheContainerName = "adal";
        private readonly CloudBlobContainer container;

        private readonly Random rand = new Random();

        private string leaseId = null;

        private DateTimeOffset? lastModified = null;
        private string lastResource = null;

        static AzureBlobTokenCache4()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudStorageAccountSetting);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(TokenCacheContainerName);
            container.DeleteIfExists();
        }

        public AzureBlobTokenCache4()
        {
            this.AfterAccess = CustomTokenCache_AfterAccess;
            this.BeforeAccess = CustomTokenCache_BeforeAccess;
            this.BeforeWrite = CustomTokenCache_BeforeWrite;

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudStorageAccountSetting);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            this.container = blobClient.GetContainerReference(TokenCacheContainerName);
            this.container.CreateIfNotExists();
        }

        void CustomTokenCache_BeforeAccess(TokenCacheAccessArgs args)
        {
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(args.Resource);
            if (blockBlob.Exists() && (lastResource != args.Resource || lastModified != blockBlob.Properties.LastModified))
            {
                byte[] blob = new byte[blockBlob.Properties.Length];
                blockBlob.DownloadToByteArray(blob, 0, AccessCondition.GenerateLeaseCondition(leaseId));
                lastResource = args.Resource;
                lastModified = blockBlob.Properties.LastModified;
            }
        }

        void CustomTokenCache_BeforeWrite(TokenCacheAccessArgs args)
        {
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(args.Resource);
            if (blockBlob.Exists() && lastModified != blockBlob.Properties.LastModified)
            {
                AcquireLease(blockBlob);
                byte[] blob = new byte[blockBlob.Properties.Length];
                blockBlob.DownloadToByteArray(blob, 0, AccessCondition.GenerateLeaseCondition(leaseId));
                this.Deserialize(blob);
            }
        }

        void CustomTokenCache_AfterAccess(TokenCacheAccessArgs args)
        {
            if (this.HasStateChanged)
            {
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(args.Resource);
                byte[] blob = this.Serialize();
                blockBlob.UploadFromByteArray(blob, 0, blob.Length, AccessCondition.GenerateLeaseCondition(leaseId));
                this.HasStateChanged = false;
                ReleaseLease(blockBlob);
            }
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
