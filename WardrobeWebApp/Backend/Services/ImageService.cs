using Backend.Models.Enums;
using Backend.Models;

namespace Backend
{
    public class ImageService : IImageService
    {
        IImageRepository _imageRepository;
        IClothingItemsRepository _clothingItemsRepository;

        public ImageService(IImageRepository imageRepository, IClothingItemsRepository clothingItemsRepository)
        {
            _imageRepository = imageRepository;
            _clothingItemsRepository = clothingItemsRepository;
        }

        public (ExecutionStatus status, string? path, string? originalFilename) FindImageByClothingItemId(int clothingItemId)
            => _clothingItemsRepository.FindClothingItemById(clothingItemId) switch
            {
                null => (ExecutionStatus.NOT_FOUND, null, null),
                ClothingItem clothingItem => FindImageByImageId(clothingItem.ImageId)
            };

        public (ExecutionStatus status, string? path, string? originalFilename) FindImageByImageId(int imageId)
        {
            return _imageRepository.FindImageByImageId(imageId);
        }
        /// <summary>
        /// Take an image, return the ID of the image
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public (ExecutionStatus status, int? id) SaveImage(IFormFile file, int? clothingItemId = null)
        {
            return _imageRepository.SaveImage(file, clothingItemId);
        }
    }
}
