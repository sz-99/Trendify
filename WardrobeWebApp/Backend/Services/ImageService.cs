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


        public (ExecutionStatus status, IFormFile? file) FindImageByClothingItemId(int clothingItemId)
        {
            return _repository.FindImageByClothingItemId(clothingItemId);
        }


        /// <summary>
        /// Take an image, return the ID of the image
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public (ExecutionStatus status, int? id) SaveImage(int clothingItemId, IFormFile file)
        {
            return _repository.SaveImage(clothingItemId, file);
        }
    }
}
