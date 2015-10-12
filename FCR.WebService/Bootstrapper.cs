//using System.Web.Mvc;
//using FCR.Core.Ioc;
//using FCR.WebService.Infrastructure;
//using Microsoft.Practices.Unity;
//using Microsoft.Practices.Unity.InterceptionExtension;

//namespace FCR.WebService
//{
//    public class Bootstrapper
//    {
//        public static void Initialize()
//        {
//            var container = BuildUnityContainer(new FindTypesInConfiguration());
//            DependencyResolver.SetResolver(new WebUiDependencyResolver(container));
//        }

//        private static IUnityContainer BuildUnityContainer(ITypeFinder typeFinder)
//        {
//            var container = new UnityContainer();
//            //Setup the container for interception
//            container.AddNewExtension<Interception>();
//            DependencyDiscovery discovery = new DependencyDiscovery(container, typeFinder, new CustomBehavior());
//            discovery.LoadContainer();

//            return container;
//        }
//    }
//}