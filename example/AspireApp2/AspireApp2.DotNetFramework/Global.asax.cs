using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AspireApp2.DotNetFramework
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private TracerProvider _tracerProvider;

        protected void Application_Start()
        {
            Debugger.Launch();

            _tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddAspNetInstrumentation()
                .AddConsoleExporter()
                .AddOtlpExporter(config =>
                {
                    config.Endpoint = new Uri(Environment.GetEnvironmentVariable("DOTNET_DASHBOARD_OTLP_ENDPOINT_URL"));
                })
                .AddSource("mvc")
                .SetResourceBuilder(
                    ResourceBuilder.CreateDefault()
                        .AddService(serviceName: "mvc", serviceVersion: "1.0.0"))

                .Build();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            _tracerProvider?.Dispose();
        }
    }
}
