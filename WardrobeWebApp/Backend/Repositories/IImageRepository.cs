using Backend.Models.Enums;

namespace Backend
{
    public interface IImageRepository
    {
        (ExecutionStatus status, int? id) SaveImage(IFormFile file);
    }
}