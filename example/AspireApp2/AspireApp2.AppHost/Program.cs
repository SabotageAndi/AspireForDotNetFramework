using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireApp2_ApiService>("apiservice");

builder.AddProject<Projects.AspireApp2_Web>("webfrontend")
    .WithReference(apiService);

//builder.AddSqlServerContainer("sql");
builder.AddExecutable("mvc", "C:\\Program Files (x86)\\IIS Express\\iisexpress.exe", Path.Combine(builder.Environment.ContentRootPath, "..", "AspireApp2.DotNetFramework"), new[] { "/config:..\\.vs\\AspireApp2\\config\\applicationhost.config", "/site:AspireApp2.DotNetFramework" });

builder.Build().Run();
