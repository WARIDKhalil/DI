using DI.container;
using DI.helpers;

namespace DI.ServiceRegistry
{
    public interface IServiceRegistry
    {
        #region Shared Attributes

        // add shared attributes here

        #endregion

        #region singleton actions

        void RegisterSingleton<TService>() where TService : class;
        void RegisterSingleton<TService>(TService service) where TService : class;
        void RegisterSingleton<TService, TImplementation>() where TImplementation : TService;

        #endregion

        #region transient actions

        void RegisterTransient<TService>() where TService : class;
        void RegisterTransient<TService, TImplementation>() where TImplementation : TService;

        #endregion

        #region common

        IContainer BuildContainer();

        #endregion
    }
}
