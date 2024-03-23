using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AspireForAspNETMvc.WebOld
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AspireForDotNetFramework.AspNetMVC5.WaitForDebugger.WaitIfNeeded();

            AspireForDotNetFramework.AspNetMVC5.OpenTelemetryIntegration.Enable();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            AspireForDotNetFramework.AspNetMVC5.OpenTelemetryIntegration.Shutdown();
        }
    }
}
