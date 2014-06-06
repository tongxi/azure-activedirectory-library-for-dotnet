using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading;

namespace ServerSideTokenCacheSample
{
    class CustomTokenCache2 : TokenCache
    {
        private const string CacheFile = "tokenCache.dat";

        private static readonly object FileLock = new object();

        static CustomTokenCache2()
        {
            File.Delete(CacheFile);            
        }

        public CustomTokenCache2()
        {
            this.AfterAccess = CustomTokenCache_AfterAccess;
            this.BeforeAccess = CustomTokenCache_BeforeAccess;
        }

        void CustomTokenCache_BeforeAccess(TokenCacheAccessArgs e)
        {
            Monitor.Enter(FileLock);
            this.Deserialize(File.Exists(CacheFile) ? File.ReadAllBytes(CacheFile) : null);
        }

        void CustomTokenCache_AfterAccess(TokenCacheAccessArgs e)
        {
            if (this.HasStateChanged)
            {
                File.WriteAllBytes(CacheFile, this.Serialize());
            }

            this.HasStateChanged = false;

            Monitor.Exit(FileLock);
        }
    }
}
