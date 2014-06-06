using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace TokenCacheSample
{
    public partial class Form1 : Form
    {
        private const string CacheFile = "tokenCache.dat";
        private const string Authority = "https://login.windows.net/aaltests.onmicrosoft.com";

        private const string Resource1 = "b7a671d8-a408-42ff-86e0-aaf447fd17c4";
        private const string Resource2 = "4848e7b1-7a6e-450e-aedb-31fd3c196db4";
        private const string ClientId = "e70b115e-ac0a-4823-85da-8f4b7b4f00e6";
        private readonly Uri RedirectUri = new Uri("https://non_existing_uri.com/");
        private const string UserName1 = "admin@aaltests.onmicrosoft.com";
        private const string UserName2 = "user@aaltests.onmicrosoft.com";

        private AuthenticationContext context;

        public Form1()
        {
            InitializeComponent();
            SetButtonsEnabledFlag(false);
        }

        private void CreateContextBbutton_Click(object sender, EventArgs e)
        {
            if (defaultStaticCacheRadioButton.Checked)
            {
                this.context = new AuthenticationContext(Authority);
                statusBox.Text += "AuthenticationContext with default static cache created.\n";
            }
            else if (emptyInstanceCacheButton.Checked)
            {
                this.context = new AuthenticationContext(Authority, new TokenCache());
                statusBox.Text += "AuthenticationContext with empty instance cache created.\n";
            }
            else if (persistedInstanceCacheRadioButton.Checked)
            {
                this.context = new AuthenticationContext(Authority, new TokenCache(File.Exists(CacheFile) ? File.ReadAllBytes(CacheFile) : null));
                statusBox.Text += "AuthenticationContext with persisted instance cache created.\n";
            }
            else
            {
                this.context = new AuthenticationContext(Authority, null);
                statusBox.Text += "AuthenticationContext with no cache created.\n";
            }

            if (this.context.TokenCache != null)
            {
                this.context.TokenCache.AfterAccess = TokenCache_AfterAccess;
            }

            SetButtonsEnabledFlag(true);
        }

        private static void TokenCache_AfterAccess(TokenCacheAccessArgs e)
        {
            if (e.TokenCache.HasStateChanged)
            {
                File.WriteAllBytes(CacheFile, e.TokenCache.Serialize());
                e.TokenCache.HasStateChanged = false;
            }
        }

        private void AcquireTokenForUserButton_Click(object sender, EventArgs e)
        {
            AcquireTokenForUser(user1RadioButton.Checked ? UserName1 : UserName2, resource1radioButton.Checked ? Resource1 : Resource2);
        }

        private void enumerateCacheItemsButton_Click(object sender, EventArgs e)
        {
            if (this.context.TokenCache == null)
            {
                statusBox.Text += "There is no cache.\n";
                return;
            }

            statusBox.Text += "Items in the cache:\n"; 
            foreach (var item in this.context.TokenCache.ReadItems())
            {
                statusBox.Text += string.Format("\tUser: {0}, Resource: {1}, AccessToken Hash: {2}\n", item.DisplayableId, item.Resource, item.AccessToken.GetHashCode());
            }
        }

        private void removeTokensForUserbutton_Click(object sender, EventArgs e)
        {
            string user = user1RadioButton2.Checked ? UserName1 : UserName2;
            int count = 0;
            foreach(var item in this.context.TokenCache.ReadItems().Where(item => item.DisplayableId == user))
            {
                this.context.TokenCache.DeleteItem(item);
                count++;
            }
            
            statusBox.Text += string.Format("{0} item(s) deleted for user {1}.\n", count, user);
        }

        private void removeTokensForResourceButton_Click(object sender, EventArgs e)
        {
            string resource = resource1RadioButton2.Checked ? Resource1 : Resource2;
            int count = 0;
            foreach (var item in this.context.TokenCache.ReadItems().Where(item => item.Resource == resource))
            {
                this.context.TokenCache.DeleteItem(item);
                count++;
            }

            statusBox.Text += string.Format("{0} item(s) deleted for resource {1}.\n", count, resource);
        }

        private void SetButtonsEnabledFlag(bool flag)
        {
            acquireTokenForUser1Button.Enabled = flag;
            enumerateCacheItemsButton.Enabled = flag;
            acquireTokenForUser1Button.Enabled = flag;
            removeTokensForUserButton.Enabled = flag;
            removeTokensForResourceButton.Enabled = flag;
        }

        private void AcquireTokenForUser(string userName, string resource)
        {
            EndBrowserDialogSession();
            var result = context.AcquireToken(resource, ClientId, RedirectUri, new UserIdentifier(userName, UserIdentifierType.OptionalDisplayableId));
            statusBox.Text += string.Format("Token with hash {0} acquired for user {1} and resource {2}.\n", result.AccessToken.GetHashCode(), userName, resource);
        }

        private static void EndBrowserDialogSession()
        {
            const int INTERNET_OPTION_END_BROWSER_SESSION = 42;
            NativeMethods.InternetSetOption(IntPtr.Zero, INTERNET_OPTION_END_BROWSER_SESSION, IntPtr.Zero, 0);
        }

        private static class NativeMethods
        {
            [DllImport("wininet.dll", SetLastError = true)]
            public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);
        }
    }
}
