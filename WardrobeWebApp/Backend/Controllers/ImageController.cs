using Azure;
using Backend.Models.Enums;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("ClothingItems/[controller]")]
    public class ImageController : ControllerBase
    {
        IImageService _imageService;

        public ImageController(IImageService imageService) 
        { 
            _imageService = imageService;
        }

        [HttpPost]
        public IActionResult PostImage(IFormFile file) => _imageService.SaveImage(file) switch
        {
            (ExecutionStatus.SUCCESS, int id) => Ok(id),
            (ExecutionStatus.ALREADY_EXISTS, _) => StatusCode(500, "Internal Server Error. File with that name already exists."),
            (ExecutionStatus.INTERNAL_SERVER_ERROR, _) => StatusCode(500, "Internal Server Error. Try again Later"),
            _ => StatusCode(500, "Unknown Internal Server Error. Try again Later")
        };


        //[HttpGet("{id}")]
        //public IActionResult GetImage(int id)
        //{
        //    IFormFile image = _imageService.FindImage(id);
        //    return Ok(image);
        //}
    }
}
