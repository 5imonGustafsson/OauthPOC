using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http;
using ADPocAct;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.ActiveDirectory;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

[assembly:Microsoft.Owin.OwinStartup(typeof(Startup))]
namespace ADPocAct
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidAudience = ""
                    },
                    Tenant = ""
                });
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            httpConfiguration.MapHttpAttributeRoutes();
            //app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            //app.UseCookieAuthentication(new CookieAuthenticationOptions());
           /* app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions()
            {
                ClientId = "",
                Authority = ""
            });*/
 
            app.UseWebApi(httpConfiguration);
        }
    }
}