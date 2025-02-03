using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OutfitController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOutfit()
        {
            return Ok();
        }
    }
}
