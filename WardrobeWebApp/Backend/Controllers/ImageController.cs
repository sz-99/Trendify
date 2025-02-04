using Azure;
using Backend.Models.Enums;
using Backend.Services;
using Backend.Utils;
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
        public IActionResult PostImage(IFormFile file) => 
            _imageService.SaveImage(file, null) switch
            {
                (ExecutionStatus.SUCCESS, int id) => Ok(id),
                (ExecutionStatus.ALREADY_EXISTS, _) => StatusCode(500, "Internal Server Error. File with that name already exists."),
                (ExecutionStatus.INTERNAL_SERVER_ERROR, _) => StatusCode(500, "Internal Server Error. Try again Later"),
                _ => StatusCode(500, "Unknown Internal Server Error. Try again Later")
            };

        [HttpGet("{clothingItemId}")]
        public IActionResult GetImage(int clothingItemId) =>
            _imageService.FindImageByClothingItemId(clothingItemId) switch
            {
                (ExecutionStatus.SUCCESS, string path, string originalFilename) => Ok(File(path, "image/png", originalFilename)),
                (ExecutionStatus.INTERNAL_SERVER_ERROR, _, _) => StatusCode(500, "Internal server error. Please try again later."),
                (ExecutionStatus.NOT_FOUND, _, _) => NotFound($"No image found for {clothingItemId}"),
                (_, _, _) => BadRequest($"Unknown error dealing with clothing item {clothingItemId}")
            };
    }
}

