using Microsoft.Practices.Unity;
using System.Web.Http;
using FCR.BLL;
using FCR.Core;
using FCR.DAL;
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
            container.RegisterType<IFCRContext, FCRContext>();
            container.RegisterType<IEquipmentLogic, EquipmentLogic>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}