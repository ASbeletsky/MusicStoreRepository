using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinyIoC;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Concrete;

namespace MusicStore.WebUI.Infrastructure
{
    public class TinyIoCMvcResolver : IDependencyResolver
    {
        private readonly TinyIoCContainer _container;

        public TinyIoCMvcResolver(TinyIoCContainer container)
        {
            _container = container;
            //AddBindings();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (Exception)
            {
                return null;
            } 
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType, true);
            }
            catch (Exception)
            {
                return Enumerable.Empty<object>();
            }  
        }

       /* private void AddBindings()
        {
            _container.Register<IMusicInstrumentRepository, EFMusicInstrumentsRepository>().AsMultiInstance();
        }*/
    }
}