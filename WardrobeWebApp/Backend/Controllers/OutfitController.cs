using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Authorize]
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
