using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace TokenCacheWinRTSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const string CacheFile = "tokenCache.dat";
        private const string Authority = "https://login.windows.net/aaltests.onmicrosoft.com";

        private const string Resource1 = "b7a671d8-a408-42ff-86e0-aaf447fd17c4";
        private const string Resource2 = "4848e7b1-7a6e-450e-aedb-31fd3c196db4";
        private const string ClientId = "e70b115e-ac0a-4823-85da-8f4b7b4f00e6";
        private readonly Uri RedicrectUri = new Uri("https://non_existing_uri.com/");
        private const string UserName1 = "admin@aaltests.onmicrosoft.com";
        private const string UserName2 = "user@aaltests.onmicrosoft.com";

        private AuthenticationContext context;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void CreateContextButtonWithDefaultCache_Click(object sender, RoutedEventArgs e)
        {
            this.context = new AuthenticationContext(Authority);
            statusBox.Text += "AuthenticationContext with default static cache created.\n";

        }

        private void CreateContextButtonWithEmptyCache_Click(object sender, RoutedEventArgs e)
        {
            this.context = new AuthenticationContext(Authority, true, new TokenCache());
            statusBox.Text += "AuthenticationContext with empty instance static cache created.\n";

        }

        private void CreateContextWithNoCacheButton_Click(object sender, RoutedEventArgs e)
        {
            this.context = new AuthenticationContext(Authority, true, null);
            statusBox.Text += "AuthenticationContext with no cache created.\n";

        }

        private void AcquireTokenForUser1AndResource1Button_Click(object sender, RoutedEventArgs e)
        {
            AcquireTokenForUserAsync(UserName1, Resource1);
        }

        private async void AcquireTokenForUserAsync(string userName, string resource)
        {
            var result = await context.AcquireTokenAsync(resource, ClientId, RedicrectUri, new UserIdentifier(userName, UserIdentifierType.OptionalDisplayableId));
            if (result.Status == AuthenticationStatus.Success)
                statusBox.Text += string.Format("Token with hash {0} acquired for user {1} and resource {2}.\n", result.AccessToken.GetHashCode(), userName, resource);
            else
                statusBox.Text += string.Format("Error in acquiring token for user {0} and resource {1}: {2}\n", userName, resource, result.ErrorDescription);
        }
    }
}
