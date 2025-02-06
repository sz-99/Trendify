using Backend.Models.Enums;

namespace Backend
{
    public interface IImageRepository
    {
        (ExecutionStatus status, int? id, string? location) AddImageLocationToDb(string filename, int? clothingItemId);
        (ExecutionStatus status, string? path, string? originalFilename) FindImagePathByClothingItemId(int clothingItemId);
        (ExecutionStatus status, string? path, string? originalFilename) FindImageByImageId(int clothingItemId);
        (ExecutionStatus status, string? path) FindLocationPathFromClothingItemId(int id);
        string GetImageLocation(string filename);
        string? OriginalFileNameFromClothingItemId(int clothingItemId);
        (ExecutionStatus status, int? clothingItemId) SaveImage(IFormFile file, int? clothingItemId);
        (ExecutionStatus status, int? id) SaveImageToDisk(IFormFile file, int id, string locationPath);
    }
}