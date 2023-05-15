using DI.enums;
using DI.helpers;

namespace DI.container
{
    public class Container : IContainer
    {
        #region attributes

        private readonly IDictionary<Type, ServiceDetails> _services;

        #endregion

        #region constructors

        public Container(IDictionary<Type, ServiceDetails> services)
        {
            _services = services;
        }

        #endregion

        #region actions

        public T? Resolve<T>()
        {
            // Get service details
            var serviceDetails = _services[typeof(T)];

            // check if it exists
            if (serviceDetails == null)
            {
                throw new Exception($"there is no service '{nameof(T)}' registred ");
            }

            // Get the implementation type in case the service type provided was an interface or abstract
            Type actualType = serviceDetails.ImplementationType ?? serviceDetails.Type;

            // avoid this case <TService, Type:Abstract/Interface>
            if(actualType.IsAbstract || actualType.IsInterface)
            {
                throw new Exception("Error : abstract/interface type was provided for instantiation");
            }

            // if lifetime is singleton
            if(serviceDetails.Lifetime == Lifetime.Singleton)
            {
                return InstantiateAsSingleton<T>(serviceDetails, actualType);
            }

            //if lifetime is Transient
            if(serviceDetails.Lifetime == Lifetime.Transient)
            {
                return InstantiateAsTransient<T>(actualType);
            }

            // return default
            return default;
        }

        #endregion

        #region helpers

        /// <summary>
        /// Handle the instantiation part as Singleton
        /// </summary>
        /// <typeparam name="T">type to resolve</typeparam>
        /// <param name="serviceDetails">details about target service</param>
        /// <param name="actualType">type to instantiate</param>
        /// <returns>instance</returns>
        private static T? InstantiateAsSingleton<T>(ServiceDetails serviceDetails, Type actualType)
        {
            // if an implementation was not provided
            serviceDetails.Implementation ??= Activator.CreateInstance(actualType);

            // return the target service
            return (T?)serviceDetails.Implementation;
        }

        /// <summary>
        /// Handle the instantiation part as Transient
        /// </summary>
        /// <typeparam name="T">type to resolve</typeparam>
        /// <param name="actualType">type to instantiate</param>
        /// <returns>instance</returns>
        private static T? InstantiateAsTransient<T>(Type actualType)
        {
            return (T?)Activator.CreateInstance(actualType);
        }

        #endregion
    }
}
