using System;

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ServerSideTokenCacheSample
{
    class AzureBlobTokenCache1 : TokenCache
    {
        private const string CloudStorageAccountSetting = "UseDevelopmentStorage=true";
        private const string TokenCacheContainerName = "adal";
        private readonly CloudBlobContainer container;

        static AzureBlobTokenCache1()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudStorageAccountSetting);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(TokenCacheContainerName);
            container.DeleteIfExists();
        }

        public AzureBlobTokenCache1()
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
            CloudBlockBlob blockBlob = this.container.GetBlockBlobReference(args.Resource);
            if (blockBlob.Exists())
            {
                byte[] blob = new byte[blockBlob.Properties.Length];
                blockBlob.DownloadToByteArray(blob, 0);
                this.Deserialize(blob);
            }
        }

        void CustomTokenCache_AfterAccess(TokenCacheAccessArgs args)
        {
            if (this.HasStateChanged)
            {
                CloudBlockBlob blockBlob = this.container.GetBlockBlobReference(args.Resource);
                byte[] blob = this.Serialize();
                blockBlob.UploadFromByteArray(blob, 0, blob.Length);
                this.HasStateChanged = false;
            }
        }
    }
}
