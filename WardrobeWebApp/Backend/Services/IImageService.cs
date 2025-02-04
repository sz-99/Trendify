
using Backend.Models.Enums;

namespace Backend
{
    public interface IImageService
    {
        (ExecutionStatus status, int? id) SaveImage(IFormFile file);

    }
}