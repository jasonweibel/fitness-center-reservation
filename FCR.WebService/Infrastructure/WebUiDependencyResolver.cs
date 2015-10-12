using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

namespace FCR.WebService.Infrastructure
{
    public class WebUiDependencyResolver : IDependencyResolver
    {
        private IDependencyResolver _resolver;
        public WebUiDependencyResolver(IUnityContainer container)
        {
            _resolver = new UnityDependencyResolver(container);
        }

        public object GetService(Type serviceType)
        {

            object returnValue = _resolver.GetService(serviceType);
            //if (returnValue != null)
            //{
            //    try
            //    {
            //        returnValue = Intercept.ThroughProxy(serviceType, returnValue, new InterfaceInterceptor(), new[] { new InterceptionBehavior() });
            //    }
            //    catch (Exception)
            //    { }

            //}

            return returnValue;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolver.GetServices(serviceType);
        }
    }
}