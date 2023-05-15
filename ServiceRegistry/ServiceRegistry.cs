using DI.container;
using DI.enums;
using DI.helpers;

namespace DI.ServiceRegistry
{
    public class ServiceRegistry : IServiceRegistry
    {
        #region attributes

        /// <summary>
        /// List of services to be resolved
        /// </summary>
        public List<ServiceDetails> Services { get; }

        #endregion

        #region constructors

        public ServiceRegistry()
        {
            Services = new List<ServiceDetails>();
        }

        #endregion

        #region singleton actions

        public void RegisterSingleton<TService>() where TService : class
        {
            Services.Add(new ServiceDetails(typeof(TService), Lifetime.Singleton));
        }

        public void RegisterSingleton<TService>(TService service) where TService : class
        {
            if(service is null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            Services.Add(new ServiceDetails(service, Lifetime.Singleton));
        }

        public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
        {
            Services.Add(new ServiceDetails(typeof(TService), typeof(TImplementation), Lifetime.Singleton));
        }

        #endregion

        #region transient actions

        public void RegisterTransient<TService>() where TService : class
        {
            Services.Add(new ServiceDetails(typeof(TService), Lifetime.Transient));
        }

        public void RegisterTransient<TService, TImplementation>() where TImplementation : TService
        {
            Services.Add(new ServiceDetails(typeof(TService), typeof(TImplementation), Lifetime.Transient));
        }

        #endregion

        #region common

        public IContainer BuildContainer()
        {
            return new Container(Services.ToDictionary(e => e.Type)); 
        }

        #endregion

    }
}
