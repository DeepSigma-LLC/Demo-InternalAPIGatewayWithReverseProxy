var builder = DistributedApplication.CreateBuilder(args);


var pessimisticAPi = builder.AddProject<Projects.PessimisticPricingAPI>("PessimisticPricingService");
var optimisticAPI = builder.AddProject<Projects.OptimisticPricingAPI>("OptimisticPricingService");

builder.AddProject<Projects.APIPricingGateway>("APIPricingGateway")
    .WithReference(pessimisticAPi)
    .WaitFor(pessimisticAPi)
    .WithReference(optimisticAPI)
    .WaitFor(optimisticAPI);

builder.Build().Run();
