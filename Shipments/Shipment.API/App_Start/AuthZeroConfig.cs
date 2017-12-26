using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System.Web.Configuration;

namespace Shipment.API
{
    public partial class Startup
    {
        private void ConfigureAuthZero(IAppBuilder app)
        {
            //Read Auth0 Configuration from Config 
            var issuer = $"http://{ WebConfigurationManager.AppSettings["auth0:Domain"] }/";
            var audience = WebConfigurationManager.AppSettings["auth0:ClientId"];
            var secret = TextEncodings.Base64.Encode(TextEncodings.Base64Url.Decode(WebConfigurationManager.AppSettings["auth0:ClientSecret"]));

            //Configure Bearer Token middleware to OWIN server
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                AllowedAudiences = new[] { audience },
                IssuerSecurityTokenProviders = new[]
                {
                    new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                }
            });
        }
    }
}