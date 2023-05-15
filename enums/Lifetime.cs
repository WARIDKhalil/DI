namespace DI.enums
{
    /// <summary>
    /// lifetime types of injectable objects
    /// </summary>
    public enum Lifetime
    {
        /// <summary>
        /// creates a single instance once and reuses the same object in all calls
        /// </summary>
        Singleton,

        /// <summary>
        /// creates an instance each time it is requested
        /// </summary>
        Transient,

        /// <summary>
        /// creates an instance once per web request
        /// </summary>
        Scoped
    }
}
