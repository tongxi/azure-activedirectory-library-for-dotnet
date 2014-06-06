using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace ServerSideTokenCacheSample
{
    internal class Program
    {
        private const string Authority = "https://login.windows.net/aaltests.onmicrosoft.com";

        private readonly static string[] Resources =
        {
            "b7a671d8-a408-42ff-86e0-aaf447fd17c4",
            "4848e7b1-7a6e-450e-aedb-31fd3c196db4",
            "3e5e5728-f57e-4d7f-b4be-87d0bdc39900"
        };

        private const string ClientId = "9083ccb8-8a46-43e7-8439-1d696df984ae";
        private const string ClientSecret = "client_secret";

        private static readonly Random rand = new Random();

        static void Main(string[] args)
        {
            ClientCredential credential = new ClientCredential(ClientId, ClientSecret);
            Parallel.For(0, 100,
                i =>
                {
                    Thread.Sleep(rand.Next(0, 300));
                    AuthenticationContext context = new AuthenticationContext(Authority, new CustomTokenCache1());
                    var result = context.AcquireToken(Resources[rand.Next(0, 3)], credential);
                });
        }
    }
}
