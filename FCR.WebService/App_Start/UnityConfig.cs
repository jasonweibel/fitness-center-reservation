using System;
using FCR.BLL;
using FCR.Core.Ioc;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace FCR.WebService
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> _container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return _container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            //var ioc = new DependencyDiscovery(new FindTypesInConfiguration(), new UnityAdapter(container, new UnityLifetimeFactory()));
            //ioc.Load();
            //ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));

            container.RegisterType<ICenterLogic, CenterLogic>();

        }
    }
}
