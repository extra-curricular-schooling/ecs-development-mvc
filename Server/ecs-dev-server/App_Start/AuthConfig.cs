using DotNetOpenAuth.LinkedInOAuth2;
using Microsoft.AspNet.Membership.OpenAuth;

namespace ecs_dev_server
{
    public class AuthConfig
    {
        public static void RegisterAuth()
        {
            if (OpenAuth.AuthenticationClients.GetByProviderName("linkedin") == null)
            {
                var client = new LinkedInOAuth2Client("86h0tsh0fansqk", "GzIEj706ElSYEWT9");
                OpenAuth.AuthenticationClients.Add("linkedin", () => client);
            }
        }
    }
}