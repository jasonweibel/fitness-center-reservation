//using System;
//using Microsoft.Practices.Unity;

//namespace FCR.Core.Ioc
//{
//    public class UnityAdapter : IDependencyContainer
//    {
//        readonly IUnityContainer container;
//        readonly IocLifetime lifetimeFactory;
//        public UnityAdapter(IUnityContainer container, IocLifetime lifetimeFactory)
//        {
//            this.container = container;
//            this.lifetimeFactory = lifetimeFactory;
//            this.container.AddNewExtension<NamedAttributeUnityExtension>();

//        }

//        public void RegisterType(Type interfaceType, Type implementationType, IocLifetime lifetime, string instanceName)
//        {
//            var manager = lifetimeFactory.CreateLifetime(lifetime);
//            container.RegisterType(interfaceType, implementationType, instanceName, manager);
//        }

//        public void RegisterType(Type interfaceType, Type implementationType, string instanceName)
//        {
//            container.RegisterType(interfaceType, implementationType, instanceName);
//        }

//        public void RegisterType(Type interfaceType, Type implementationType, IocLifetime lifetime)
//        {
//            var manager = lifetimeFactory.CreateLifetime(lifetime);
//            container.RegisterType(interfaceType, implementationType, manager);
//        }

//        public void RegisterType(Type interfaceType, Type implementationType)
//        {
//            container.RegisterType(interfaceType, implementationType);
//        }
//    }
//}