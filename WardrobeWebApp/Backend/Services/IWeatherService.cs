
using Backend.Models;
using Backend.Models.Enums;

namespace Backend.Services
{
    public interface IWeatherService
    {
        Task<(ExecutionStatus, WeatherInfo?)> GetWeatherForecast(string location);
    }
}