using Backend.Models.Enums;

namespace Backend
{
    public interface IImageService
    {
        (ExecutionStatus status, string? path, string? originalFilename) FindImageByClothingItemId(int clothingItemId);
        (ExecutionStatus status, int? id) SaveImage(IFormFile file, int? clothingItemId);
        (ExecutionStatus status, string? path, string? originalFilename) FindImageByImageId(int imageId);
    }
}