namespace FCR.Core.Ioc
{
    /// <summary>
    /// Indicates how lifetime will be managed.
    /// https://mvcarchstarter.svn.codeplex.com/svn/Core/Ioc/IocLifetime.cs
    /// </summary>
    public enum IocLifetime
    {
        /// <summary>
        /// Each call into the container results in a new instance.
        /// </summary>
        Instance,
        /// <summary>
        /// Each call into the container returns the same instance.
        /// </summary>
        Singleton,

        Hierarchical
    }
}
