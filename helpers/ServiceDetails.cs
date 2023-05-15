using DI.enums;

namespace DI.helpers
{
    /// <summary>
    /// Description of a service registred in the IoC container
    /// </summary>
    public class ServiceDetails
    {
        #region attributes

        /// <summary>
        /// Service type
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Implementation type for a service
        /// </summary>
        public Type? ImplementationType { get; }

        /// <summary>
        /// instance of service
        /// </summary>
        public object? Implementation { get; set; }

        /// <summary>
        /// Lifetime of service
        /// </summary>
        public Lifetime Lifetime { get; }

        #endregion

        #region constructors

        public ServiceDetails(object implementation, Lifetime lifetime)
        {
            Type = implementation.GetType();
            Implementation = implementation;
            Lifetime= lifetime;
        }

        public ServiceDetails(Type serviceType, Lifetime lifetime)
        {
            Type = serviceType;
            Lifetime = lifetime;
        }

        public ServiceDetails(Type serviceType, Type implementationType, Lifetime lifetime) 
        {
            Type = serviceType;
            ImplementationType = implementationType;
            Lifetime = lifetime;
        }

        #endregion
    }
}
