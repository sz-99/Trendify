using Backend.Models.Enums;

namespace Backend
{
    public interface IImageRepository
    {
        (ExecutionStatus status, int? id, string? location) AddImageLocationToDb(int clothingItemId, string filename);
        (ExecutionStatus status, FileStream? file) FindImageByClothingItemId(int clothingItemId);
        (ExecutionStatus status, string? path) FindLocationPathFromClothingItemId(int id);
        string GetImageLocation(string filename);
        (ExecutionStatus status, FileStream? file) FileStreamFromPath(string path, string filename);
        string? OriginalFileNameFromClothingItemId(int clothingItemId);
        (ExecutionStatus status, int? clothingItemId) SaveImage(int clothingItemId, IFormFile file);
        (ExecutionStatus status, int? id) SaveImageToDisk(IFormFile file, int id, string locationPath);
    }
}