using Microsoft.Practices.Unity;
using System.Web.Http;
using FCR.BLL;
using FCR.Core;
using Unity.WebApi;

namespace FCR.WebService
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ICenterLogic, CenterLogic>();
            container.RegisterType<IDate, DateLogic>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}