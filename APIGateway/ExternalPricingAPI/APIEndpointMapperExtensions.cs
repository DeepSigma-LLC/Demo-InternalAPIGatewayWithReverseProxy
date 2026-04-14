namespace OptimisticPricingAPI;

internal static class APIEndpointMapperExtensions
{
    internal static void MapCustomEndpoints(this WebApplication app)
    {
        app.MapGet("/getprice", () =>
        {
            return new PriceForecast("Optimistic Pricing API", DateTime.Today, 100m, 500m);
        })
        .WithName("GetPrice");

        app.MapGet("/home", () =>
        {
            return "Hello from Optimistic Pricing API!";
        })
        .WithName("Home");
    }
}
