var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Swetugg_ApiService>("apiservice");

builder.AddProject<Projects.Swetugg_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
