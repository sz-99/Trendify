using Backend.Models.Enums;

namespace Backend
{
    public class ImageService : IImageService
    {
        IImageRepository _repository;

        public ImageService(IImageRepository repository)
        {
            _repository = repository;
        }

        

        /// <summary>
        /// Take an image, return the ID of the image
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public (ExecutionStatus status, int? id) SaveImage(IFormFile file)
        {
            return _repository.SaveImage(file);
        }
    }
}
