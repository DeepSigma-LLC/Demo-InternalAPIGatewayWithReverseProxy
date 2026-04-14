namespace PessimisticPricingAPI;

internal static class APIEndpointMapperExtensions
{
    internal static void MapCustomEndpoints(this WebApplication app)
    {
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
    }
}
