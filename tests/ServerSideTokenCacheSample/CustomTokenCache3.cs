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
    class CustomTokenCache3 : TokenCache
    {
        private const string CacheFile = "tokenCache.dat";

        private static readonly ReaderWriterLockSlim RWLock = new ReaderWriterLockSlim();

        static CustomTokenCache3()
        {
            File.Delete(CacheFile);
        }

        public CustomTokenCache3()
        {
            this.AfterAccess = CustomTokenCache_AfterAccess;
            this.BeforeAccess = CustomTokenCache_BeforeAccess;
        }

        void CustomTokenCache_BeforeAccess(TokenCacheAccessArgs e)
        {
            RWLock.EnterReadLock();
            this.Deserialize(File.Exists(CacheFile) ? File.ReadAllBytes(CacheFile) : null);
            RWLock.ExitReadLock();
        }

        void CustomTokenCache_AfterAccess(TokenCacheAccessArgs e)
        {
            if (this.HasStateChanged)
            {
                RWLock.EnterWriteLock();
                File.WriteAllBytes(CacheFile, this.Serialize());
                this.HasStateChanged = false;
                RWLock.ExitWriteLock();
            }
        }
    }
}
