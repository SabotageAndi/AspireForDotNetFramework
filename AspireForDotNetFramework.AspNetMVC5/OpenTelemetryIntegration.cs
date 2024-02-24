using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireForDotNetFramework.AspNetMVC5
{
    public static class OpenTelemetryIntegration
    {
        private static TracerProvider _tracerProvider;

        public static void Enable()
        {
            _tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddAspNetInstrumentation()
                .AddOtlpExporter(config =>
                {
                    config.Endpoint = new Uri(Environment.GetEnvironmentVariable("DOTNET_DASHBOARD_OTLP_ENDPOINT_URL"));
                })
                .AddSource("ASP_NET_MVC_Frontend")
                .SetResourceBuilder(
                    ResourceBuilder.CreateDefault()
                        .AddService(serviceName: "ASP_NET_MVC_Frontend", serviceVersion: "1.0.0"))

                .Build();
        }

        public static void Shutdown()
        {
            _tracerProvider?.Dispose();
        }
    }
}
