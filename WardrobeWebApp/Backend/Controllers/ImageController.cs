using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        IImageService _imageService;

        public ImageController(IImageService imageService) 
        { 
            _imageService = imageService;
        }

        [HttpPost]
        public IActionResult PostImage(IFormFile file)
        {
            var result = _imageService.SaveImage(file);
            return Ok(result);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetImage(int id)
        //{

        //}
    }
}
