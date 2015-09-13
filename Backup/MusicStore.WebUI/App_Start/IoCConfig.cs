
namespace MusicStore.WebUI.App_Start
{
    using System;
    using System.Web;
    using MusicStore.Domain.Abstract;
    using MusicStore.Domain.Concrete;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using TinyIoC;
    using WebUI.Infrastructure;

    public static class IoCConfig
    {
        public static void Register()
        {
            // Get IoC container
            var container = new TinyIoC.TinyIoCContainer();

            // Register context, unit of work and repos with per request lifetime
            container.Register<IMusicInstrumentRepository, EFMusicInstrumentsRepository>().AsPerRequestSingleton();


            // Set MVC dep resolver
            System.Web.Mvc.DependencyResolver.SetResolver(new TinyIoCMvcResolver(container));
        }
    }
}
