using OptimisticPricingAPI;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.AddServiceDefaults();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

// Map custom endpoints defined in APIEndpointMapper
app.MapCustomEndpoints();

app.MapDefaultEndpoints();
app.Run();

internal record PriceForecast(string Source, DateTime Date, decimal Price, decimal TargetPrice);
