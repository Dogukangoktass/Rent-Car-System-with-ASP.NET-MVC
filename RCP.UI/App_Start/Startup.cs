using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Owin;
using RCP.UI.Facebook;

[assembly: OwinStartup(typeof(RCP.UI.App_Start.Startup))]

namespace RCP.UI.App_Start
{
    public class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            // and also store information about a user logging in with a third party login provider.
            // This is required if your application allows users to login
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //    LoginPath = new PathString("/Account/Login")
            //});
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "1235334876676302",
            //   appSecret: "169dd405cc9a14369f5a3c09f9a12688");

            var facebookOptions = new FacebookAuthenticationOptions()
            {
                AppId="1235334876676302",
               AppSecret="169dd405cc9a14369f5a3c09f9a12688",
               BackchannelHttpHandler=new FacebookBackChannelHandler(),
               UserInformationEndpoint= "https://graph.facebook.com/v2.4/me?fields=id,email&access_token=ABC"
            };
            facebookOptions.Scope.Add("email");
            app.UseFacebookAuthentication(facebookOptions);

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "942731914284-tqskvqog17skfgoas2i8ofon6glm3pvk.apps.googleusercontent.com",
                ClientSecret = "GOvT0my-kKvSyT5wXEZypltU"
            });
        }
    }
}
