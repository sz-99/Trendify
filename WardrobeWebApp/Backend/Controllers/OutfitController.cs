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
        [HttpGet]
        public IActionResult GetOutfit()
        {
            var (status, outfit) = _outfitService.MakeOutfitToList();
            if(status == Models.Enums.ExecutionStatus.SUCCESS) 
            return Ok(outfit);

            return BadRequest();
        }
    }
}
