using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;
using System.Web.Routing;
using FCR.WebService.App_Start;

namespace FCR.WebService
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            //AuthConfig.RegisterAuth();

            // Bootstrapper.Initialize();

            RegisterFilterProviders();

            GlobalConfiguration.Configuration.EnsureInitialized();
        }

        //protected void Application_Start()
        //{
        //    GlobalConfiguration.Configure(WebApiConfig.Register);
        //    RegisterFilterProviders();
        //}

        public static void RegisterFilterProviders()
        {
            var providers = GlobalConfiguration.Configuration.Services.GetFilterProviders().ToList();
            GlobalConfiguration.Configuration.Services.Add(typeof(IFilterProvider),
                                                            new UnityActionFilterProvider(UnityConfig.GetConfiguredContainer()));

            var defaultprovider = providers.First(p => p is ActionDescriptorFilterProvider);
            GlobalConfiguration.Configuration.Services.Remove(typeof(IFilterProvider), defaultprovider);
        }
    }
}
