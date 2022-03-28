using Microsoft.Extensions.Caching.Distributed;

namespace DistributedCache.Extensions
{
    internal static class LoadForecast
    {
        public static async Task<object> GetForecast(
            this IDistributedCache cache)
        {
            WeatherForecast[]? forecasts = null; //Declaring empty forecasts
            string? loadLocation = null; //Declaring empty loadLocation

            string recordKey = $"WeatherForecast_{DateTime.Now:yyyyMMdd_hhmm}"; //Declaring a unit recordKey to set our get the data

            forecasts = await cache.GetRecordAsync<WeatherForecast[]>(recordKey);

            if (forecasts is not null)
            {
                loadLocation = $"Loaded from the cache at { DateTime.Now }";

                return new { LoadLocation = loadLocation, Forecasts = forecasts };
            }

            var summaries = new[]
            {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

            await Task.Delay(1500);

            forecasts = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateTime.Now.AddDays(index),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToArray();

            loadLocation = $"Loaded from the Database at { DateTime.Now }";

            await cache.SetRecordAsync(recordKey, forecasts);

            return new { LoadLocation = loadLocation, Forecasts = forecasts };
        }
    }
}
