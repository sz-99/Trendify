using Backend.Models.Enums;

namespace Backend
{
    public interface IImageService
    {
        (ExecutionStatus status, FileStream? file) FindImageByClothingItemId(int clothingItemId);
        (ExecutionStatus status, int? id) SaveImage(int clothingItemId, IFormFile file);
    }
}