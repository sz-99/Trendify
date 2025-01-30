using Microsoft.AspNetCore.Mvc;

namespace RecordShop
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        public HealthController() { }

        [HttpGet]
        public IActionResult GetHealthStatus()
        {
            return Ok("Server is running");
        }

    }
}
