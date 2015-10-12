//using Microsoft.Practices.Unity;

//namespace FCR.Core.Ioc
//{
//    public interface IUnityLifetimeFactory
//    {
//        LifetimeManager CreateLifetime(IocLifetime lifetime);
//    }
//    public class UnityLifetimeFactory : IUnityLifetimeFactory
//    {
//        public LifetimeManager CreateLifetime(IocLifetime lifetime)
//        {
//            LifetimeManager manager;
//            switch (lifetime)
//            {
//                case IocLifetime.Singleton:
//                    manager = new ContainerControlledLifetimeManager();
//                    break;

//                case IocLifetime.Hierarchical:
//                    manager = new HierarchicalLifetimeManager();
//                    break;
//                default:
//                case IocLifetime.Instance:
//                    manager = new TransientLifetimeManager();
//                    break;
//            }

//            return manager;
//        }
//    }
//}