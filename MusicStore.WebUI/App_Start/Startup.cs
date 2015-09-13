using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using MusicStore.Domain.Entities;

[assembly: OwinStartup(typeof(MusicStore.WebUI.App_Start.Startup))]

namespace MusicStore.WebUI.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Дополнительные сведения о настройке приложения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=316888
            app.CreatePerOwinContext<MyIdentityContext>(MyIdentityContext.Create);
            app.CreatePerOwinContext<UserManagerIntPK>(UserManagerIntPK.Create);

            app.SetDefaultSignInAsAuthenticationType(DefaultAuthenticationTypes.ApplicationCookie);
            app.UseCookieAuthentication(new CookieAuthenticationOptions            
            {              
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
                //LoginPath = new PathString("/Authorization/LogIn") //редирект если не авторизирован
            });

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions() 
            {
                ClientId = "489008369212-nsbcfvhhsf46vto7e82la2ko3fb5ck5f.apps.googleusercontent.com",
                ClientSecret = "qLFPYsXxVz50EvOClJTHZkyO"
            });
        }
    }
}
