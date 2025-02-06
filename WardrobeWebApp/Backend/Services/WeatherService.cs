using Backend.Models;
using Backend.Models.Enums;
using System.Net.Http;
using System.Text.Json;

namespace Backend.Services
{
    public class WeatherService : IWeatherService
    {
        public string ApiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY");
        private static HttpClient _httpClient = new ();

        public async Task<(ExecutionStatus, WeatherInfo?)> GetWeatherForecast(string location)
        {
           try
            {
                string url = $"https://api.weatherapi.com/v1/forecast.json?key={ApiKey}&q={location}&days=1";
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                var doc = JsonDocument.Parse(jsonResponse);
            
                var root = doc.RootElement;
                string loc = root.GetProperty("location").GetProperty("name").GetString() ?? "Unknown";
                var forecastDay = root.GetProperty("forecast").GetProperty("forecastday")[0].GetProperty("day");

                var weather = new WeatherInfo()
                {
                    Location = loc,
                    MinTemp = forecastDay.GetProperty("mintemp_c").GetSingle(),
                    MaxTemp = forecastDay.GetProperty("maxtemp_c").GetSingle(),
                    AvgTemp = forecastDay.GetProperty("avgtemp_c").GetSingle(),
                    Precipitation = forecastDay.GetProperty("totalprecip_mm").GetSingle(),
                    Condition = forecastDay.GetProperty("condition").GetProperty("text").GetString() ?? "Unknown",
                    ConditionIconUrl = "https:" + forecastDay.GetProperty("condition").GetProperty("icon")
                };
                return (ExecutionStatus.SUCCESS, weather);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching weather: {ex.Message}");
                return (ExecutionStatus.NOT_FOUND, null);
            }

        }
    }
}
