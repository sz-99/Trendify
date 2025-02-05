using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OutfitController : ControllerBase
    {
        IOutfitService _outfitService;
        public OutfitController(IOutfitService outfitService)
        {
            _outfitService = outfitService;
        }
        [HttpGet("{location}")]
        public IActionResult GetOutfit(string location)
        {
            var (status, outfit) = _outfitService.MakeOutfitToList(location).Result;
            if(status == Models.Enums.ExecutionStatus.SUCCESS) 
            return Ok(outfit);

            return BadRequest();
        }
    }
}
