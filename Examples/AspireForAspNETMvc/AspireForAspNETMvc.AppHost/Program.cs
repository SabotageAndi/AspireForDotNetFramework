using AspireForDotNetFramework.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireForAspNETMvc_ApiService>("apiservice");

builder.AddProject<Projects.AspireForAspNETMvc_Web>("webfrontend")
    .WithReference(apiService);

var sqlServer = builder.AddSqlServerContainer("sqlServer").
    AddDatabase("AspireForAspNETMvc.WebOld");



var aspnetMVC = builder.AddAspNetMVC<Projects.AspireForAspNETMvc_WebOld>("ASP_NET_MVC_Frontend").WithReference(sqlServer);
    


builder.Build().Run();
