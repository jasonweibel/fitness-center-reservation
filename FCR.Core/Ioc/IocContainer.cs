//using System;
//using System.Linq;

//namespace FCR.Core.Ioc
//{
//    public class IocContainer
//    {
//        readonly IDependencyContainer _container;
//        readonly ITypeFinder _typeFinder;
//        public IocContainer(ITypeFinder typeFinder, IDependencyContainer container)
//        {
//            _typeFinder = typeFinder;
//            _container = container;
//        }

//        public void Load()
//        {
//            var types = _typeFinder.GetTypes();

//            foreach (var type in types)
//            {
//                var dependencyAttributes = type.GetCustomAttributes(typeof(DependencyDiscoveryAttribute), false);

//                if (dependencyAttributes.Any())
//                {
//                    var dependencyAttribute = dependencyAttributes.Cast<DependencyDiscoveryAttribute>().FirstOrDefault();
//                    AddToContainer(dependencyAttribute, type);
//                }
//            }
//        }

//        private void AddToContainer(DependencyDiscoveryAttribute dependencyAttribute, Type type)
//        {
//            if (string.IsNullOrEmpty(dependencyAttribute.InstanceName))
//                HandleUnamedRegistration(dependencyAttribute, type);
//            else
//                HandleNamedRegistration(dependencyAttribute, type);
//        }

//        private void HandleUnamedRegistration(DependencyDiscoveryAttribute dependencyAttribute, Type type)
//        {
//            _container.RegisterType(dependencyAttribute.InterfaceType, type, dependencyAttribute.Lifetime);
//        }

//        private void HandleNamedRegistration(DependencyDiscoveryAttribute dependencyAttribute, Type type)
//        {
//            _container.RegisterType(dependencyAttribute.InterfaceType, type, dependencyAttribute.Lifetime, dependencyAttribute.InstanceName);
//        }

//    }
//}