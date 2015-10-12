using System;

namespace FCR.Core.Ioc
{
    /// <summary>
    /// Provides access to register a type in the container.
    /// https://searchcode.com/codesearch/view/28825011/
    /// https://searchcode.com/codesearch/view/28791505/
    /// https://code.google.com/r/saxman-nhin-d/source/browse/csharp/common/Container/?name=config-store-1.1
    /// </summary>

    public interface IDependencyContainer
    {
        /// <summary>
        /// Register a type with the default lifetime.
        /// </summary>
        /// <param name="interfaceType">The type to resolve.</param>
        /// <param name="implementationType">The type resolved to.</param>
        void RegisterType(Type interfaceType, Type implementationType);

        /// <summary>
        /// Register a type with the specified lifetime.
        /// </summary>
        /// <param name="interfaceType">The type to resolve.</param>
        /// <param name="implementationType">The type resolved to.</param>
        /// <param name="lifetime">The lifetime of the resolved type.</param>
        void RegisterType(Type interfaceType, Type implementationType, IocLifetime lifetime);

        /// <summary>
        /// Register a type with the default lifetime with the specified name.
        /// </summary>
        /// <param name="interfaceType">The type to resolve.</param>
        /// <param name="implementationType">The type resolved to.</param>
        /// <param name="instanceName">The named instance.</param>
        void RegisterType(Type interfaceType, Type implementationType, string instanceName);
    }
}