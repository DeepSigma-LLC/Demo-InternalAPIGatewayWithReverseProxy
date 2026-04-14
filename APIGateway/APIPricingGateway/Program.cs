using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("pricing-rate-limit", opt =>
    {
        opt.Window = TimeSpan.FromSeconds(10);
        opt.PermitLimit = 5;
        //opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        //opt.QueueLimit = 2;
        opt.QueueLimit = 0; // Don't allow queuing, immediately reject requests that exceed the limit
    });
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
});

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddServiceDiscoveryDestinationResolver();

var app = builder.Build();

app.MapDefaultEndpoints();
app.UseRateLimiter();
app.MapReverseProxy();
app.Run();

