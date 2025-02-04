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
            var weather = await _weatherService.GetWeatherForecast(location);
            if (weather == null) {return NotFound();}
            return Ok(weather);
        }
    }
}
