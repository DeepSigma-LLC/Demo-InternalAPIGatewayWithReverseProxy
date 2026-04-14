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

app.MapGet("/getprice", () =>
{
    return new PriceForecast("Pessimistic Pricing API", DateTime.Today, 100m, 30m);
})
.WithName("GetPrice");

app.MapGet("/home", () =>
{
    return "Hello from Pessimistic Pricing API :(";
})
.WithName("Home");

app.MapDefaultEndpoints();
app.Run();

internal record PriceForecast(string Source, DateTime Date, decimal Price, decimal TargetPrice);
