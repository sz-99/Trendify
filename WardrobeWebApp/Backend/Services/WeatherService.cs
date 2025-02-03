using Backend.Models;
using System.Net.Http;
using System.Text.Json;

namespace Backend.Services
{
    public class WeatherService : IWeatherService
    {
        public string Api_Key = "c6a2a089ddc24ce7840142448250302";
        private static HttpClient _httpClient = new ();

        public async Task<WeatherInfo?> GetWeatherForecast(string location)
        {
            string url = $"https://api.weatherapi.com/v1/forecast.json?key={Api_Key}&q={location}&days=1";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            


            Console.WriteLine(jsonResponse);
            return new WeatherInfo() { };
        }
    }
}
