
namespace Backend
{
    public interface IImageRepository
    {
        int SaveImage(IFormFile file);
    }
}