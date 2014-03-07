using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace NakedIdentity.Mvc
{
    public class Startup
    {
        public const string AuthenticationType = "ApplicationCookie";
        
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = AuthenticationType,
                LoginPath = new PathString("/auth/login")
            });
        }
    }
}   