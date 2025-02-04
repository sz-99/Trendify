using Backend.Models;
using Backend.Models.Enums;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : Controller
    {
        IWeatherService _weatherService;
        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        [HttpGet("{location}")]
        public async Task<IActionResult> GetWeatherForcast(string location)
        {
            var response = await _weatherService.GetWeatherForecast(location);
            WeatherInfo weather = response.Item2;
            return response.Item1 switch
            {
                ExecutionStatus.SUCCESS => Ok(weather),
                _ => NotFound()
            };
        }
    }
}
