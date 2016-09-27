using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace power_bi_table_clear
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Authenticator auth = new Authenticator();
            auth.GenerateAuth();
        }
    }

    class Authenticator
    {
        [STAThread]
        public void GenerateAuth()
        {
            Debug.WriteLine("Got here");
            string resourceUri = "https://analysis.windows.net/powerbi/api";
            string clientId = "493961b1-47aa-4b7f-a869-415c4bc26ff8";
            string redirectUri = "http://localhost";
            //OAuth2 authority Uri
            string authorityUri = "https://login.windows.net/common/oauth2/authorize";
            AuthenticationContext authContext = new AuthenticationContext(authorityUri);

            string token = authContext.AcquireToken(resourceUri, clientId, new Uri(redirectUri), PromptBehavior.Always).AccessToken;

            Console.WriteLine($"token: Bearer {token} \n\n");

            Clipboard.SetText($"Bearer {token}");
            Console.WriteLine("Copied to clipboard...");
            Console.ReadLine();
        }
    }
}
