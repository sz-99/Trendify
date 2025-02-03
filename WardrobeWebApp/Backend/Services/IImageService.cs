
namespace Backend.Services
{
    public interface IImageService
    {
        int SaveImage(string filename, IFormFile file);
    }
}