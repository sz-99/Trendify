
using Backend.Models;

namespace Backend.Services
{
    public interface IWeatherService
    {
        Task<WeatherInfo?> GetWeatherForecast(string location);
    }
}