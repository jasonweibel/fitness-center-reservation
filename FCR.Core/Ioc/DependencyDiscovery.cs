using System;
using System.Linq;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace FCR.Core.Ioc
{
    /// <summary>
    /// Uses the specified type finder to add types to the specified container.
    /// https://searchcode.com/codesearch/view/28825015/
    /// </summary>
    /// <summary>
    /// Uses the specified type finder to add types to the specified container.
    /// </summary>
    public class DependencyDiscovery
    {
        private readonly IUnityContainer _container;
        private readonly ITypeFinder _typeFinder;
        private readonly IInterceptionBehavior _interceptionBehavior;

        /// <summary>
        /// Construct an instance with container and type finder to use.
        /// </summary>
        /// <param name="container">The container to populate.</param>
        /// <param name="typeFinder">The type finder used to get the types.</param>
        public DependencyDiscovery(IUnityContainer container, ITypeFinder typeFinder, IInterceptionBehavior interceptionBehavior)
        {
            _container = container;
            _typeFinder = typeFinder;
            _interceptionBehavior = interceptionBehavior;
        }

        /// <summary>
        /// Populates the container with the types found with the type finder.
        /// </summary>
        public void LoadContainer()
        {
            Type[] types = _typeFinder.GetTypes();
            LoadTypes(types);
        }

        /// <summary>
        /// Adds the types to the container that are decorated with the DependencyDiscoveryAttribute.
        /// </summary>
        /// <param name="types">All types found by the finder.</param>
        private void LoadTypes(Type[] types)
        {
            foreach (Type type in types)
            {
                object[] dependencyAttributes = type.GetCustomAttributes(typeof(DependencyDiscoveryAttribute), false);

                if (dependencyAttributes.Any())
                {
                    foreach (DependencyDiscoveryAttribute dependencyAttribute in dependencyAttributes)
                    {
                        if (string.IsNullOrEmpty(dependencyAttribute.InstanceName))
                        {
                            _container.RegisterType(dependencyAttribute.InterfaceType, type, GetUnityLifetime(dependencyAttribute.Lifetime));
                        }
                        else
                        {
                            _container.RegisterType(dependencyAttribute.InterfaceType, type, dependencyAttribute.InstanceName, GetUnityLifetime(dependencyAttribute.Lifetime));
                        }
                        //Setup the type for interception (AOP)
                        _container.RegisterType(dependencyAttribute.InterfaceType, new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior(_interceptionBehavior));
                    }
                }
            }
        }

        private LifetimeManager GetUnityLifetime(IocLifetime iocLifetime)
        {
            switch (iocLifetime)
            {
                case IocLifetime.Instance:
                    return new TransientLifetimeManager();

                case IocLifetime.Singleton:
                    return new ContainerControlledLifetimeManager();

                case IocLifetime.Hierarchical:
                    return new HierarchicalLifetimeManager();

                default:
                    throw new NotImplementedException("Invalid IocLifetime!");
            }

        }
    }
}