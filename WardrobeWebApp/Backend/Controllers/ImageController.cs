using Azure;
using Backend.Models.Enums;
using Backend.Services;
using Backend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Backend.Controllers
{
    [Authorize]
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

        //[HttpGet("clothingId/{clothingItemId}")]
        //public IActionResult GetImageByClothingId(int clothingItemId) => _imageService.FindImageByClothingItemId(clothingItemId) switch
        //{
        //    (ExecutionStatus.SUCCESS, string path, string originalFilename) => Ok(FileUtils.FileResultFromFilePath(path, originalFilename)),
        //    (ExecutionStatus.INTERNAL_SERVER_ERROR, _, _) => StatusCode(500, "Internal server error. Please try again later."),
        //    (ExecutionStatus.NOT_FOUND, _, _) => NotFound($"No image found for {clothingItemId}"),
        //    (_, _, _) => BadRequest($"Unknown error dealing with clothing item {clothingItemId}")
        //};

        //[HttpGet("imageId/{imageId}")]
        //public IActionResult GetImageByImageId(int imageId) =>
        //    _imageService.FindImageByImageId(imageId) switch
        //    {
        //        (ExecutionStatus.SUCCESS, string path, string originalFilename) => Ok(FileUtils.FileResultFromFilePath(path, originalFilename)),
        //        (ExecutionStatus.INTERNAL_SERVER_ERROR, _, _) => StatusCode(500, "Internal server error. Please try again later."),
        //        (ExecutionStatus.NOT_FOUND, _, _) => NotFound($"No image found for {imageId}"),
        //        (_, _, _) => BadRequest($"Unknown error dealing with clothing item {imageId}")
        //    };

        [HttpGet("clothingId/{clothingItemId}")]
        public IActionResult GetImageByClothingId(int clothingItemId) 
        {
            var (status, path, originalFilename) = _imageService.FindImageByClothingItemId(clothingItemId);

            if (status == ExecutionStatus.SUCCESS)
            {

                var absoluteFilePath = Path.Combine(Directory.GetCurrentDirectory(), path);

                return PhysicalFile(absoluteFilePath, GetMimeType(absoluteFilePath), originalFilename);
             }

            return status switch
            {
                ExecutionStatus.INTERNAL_SERVER_ERROR => StatusCode(500, "Internal server error. Please try again later."),
                ExecutionStatus.NOT_FOUND => NotFound($"No image found for the clothing {clothingItemId}"),
                _ => BadRequest($"Unknown error dealing with clothing item {clothingItemId}")
            };
}


        [HttpGet("imageId/{imageId}")]
        public IActionResult GetImageByImageId(int imageId)
        {
            var (status, path, originalFilename) = _imageService.FindImageByImageId(imageId);

            if (status == ExecutionStatus.SUCCESS)
            {

                var absoluteFilePath = Path.Combine(Directory.GetCurrentDirectory(), path);

                return PhysicalFile(absoluteFilePath, GetMimeType(absoluteFilePath), originalFilename);
            }

            return status switch
            {
                ExecutionStatus.INTERNAL_SERVER_ERROR => StatusCode(500, "Internal server error. Please try again later."),
                ExecutionStatus.NOT_FOUND => NotFound($"No image found for {imageId}"),
                _ => BadRequest($"Unknown error dealing with clothing item {imageId}")
            };
        }
        private string GetMimeType(string filePath)
        {
            var provider = new FileExtensionContentTypeProvider();
            return provider.TryGetContentType(filePath, out var contentType) ? contentType : "application/octet-stream";
        }
    }
}

