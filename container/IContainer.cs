namespace DI.container
{
    public interface IContainer
    {
        #region Shared Attributes

        // add shared attributes here

        #endregion

        #region actions

        T? Resolve<T>();

        #endregion
    }
}
