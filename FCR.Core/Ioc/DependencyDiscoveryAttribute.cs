
using System;

namespace FCR.Core.Ioc
{
    /// <summary>
    /// Decorates a class to indicate that it is to be registered as a resolution of the
    /// specified interface type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DependencyDiscoveryAttribute : Attribute
    {
        /// <summary>
        /// Construct an instance of this attribute with the default lifetime
        /// of IocLifetime.Instance.
        /// </summary>
        /// <param name="interfaceType">The interface type to be resolved.</param>
        public DependencyDiscoveryAttribute(Type interfaceType) :
            this(interfaceType, IocLifetime.Instance)
        {
        }

        /// <summary>
        /// Construct an instance of this attribute with the specified values.
        /// </summary>
        /// <param name="interfaceType">The interface type to be resolved.</param>
        /// <param name="lifetime">The lifetime of the type resolution.</param>
        public DependencyDiscoveryAttribute(Type interfaceType, IocLifetime lifetime)
        {
            InterfaceType = interfaceType;
            Lifetime = lifetime;
        }

        /// <summary>
        /// Construct an instance of this attribute with the specified values.
        /// </summary>
        /// <param name="interfaceType">The interface type to be resolved.</param>
        /// <param name="lifetime">The lifetime of the type resolution.</param>
        /// <param name="instanceName">Named instance</param>
        public DependencyDiscoveryAttribute(Type interfaceType, IocLifetime lifetime, string instanceName) :
            this(interfaceType, lifetime)
        {
            InstanceName = instanceName;
        }


        /// <summary>
        /// Construct an instance of this attribute with the specified values.
        /// </summary>
        /// <param name="interfaceType">The interface type to be resolved.</param>
        /// <param name="instanceName">Named instance</param>
        public DependencyDiscoveryAttribute(Type interfaceType, string instanceName) :
            this(interfaceType)
        {
            InstanceName = instanceName;
        }


        /// <summary>
        /// The interface type to be resolved.
        /// </summary>
        public Type InterfaceType
        {
            get;
            set;
        }

        /// <summary>
        /// The lifetime of the type resolution.
        /// </summary>
        public IocLifetime Lifetime
        {
            get;
            set;
        }

        /// <summary>
        /// Used for named instances
        /// </summary>
        public string InstanceName
        {
            get;
            set;
        }
    }
}
