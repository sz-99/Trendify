using Backend.Models;
using Backend.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Backend
{
    public class ImageRepository : IImageRepository
    {
        string ImageFolder { get; set; } = @".\Resources\Images\";
        WardrobeDBContext _dbContext;

        public ImageRepository(WardrobeDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public (ExecutionStatus status, int? id, string? location) AddImageLocationToDb(int clothingItemId, string filename)
        {
            try
            {
                var locationPath = GetImageLocation(filename);
                var imageLocation = new ImageLocation(clothingItemId, locationPath, filename);
                _dbContext.ImageLocations.Add(imageLocation);
                _dbContext.SaveChanges();
                return (ExecutionStatus.SUCCESS, imageLocation.Id, locationPath);
            }
            catch
            {
                return (ExecutionStatus.INTERNAL_SERVER_ERROR, null, null);
            }
        }

        public (ExecutionStatus status, string? path) FindLocationPathFromClothingItemId(int id) =>
            _dbContext.ImageLocations.FirstOrDefault(il => il.ClothingItemId == id) switch
            {
                null => (ExecutionStatus.NOT_FOUND, null),
                ImageLocation location => (ExecutionStatus.SUCCESS, location.LocationPath)
            };

        public (ExecutionStatus status, FileStream? file) FileStreamFromPath(string path, string filename)
        {
            try
            {
                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    return (ExecutionStatus.SUCCESS, fileStream);
                }
            }
            catch
            {
                return (ExecutionStatus.INTERNAL_SERVER_ERROR, null);
            }
        }

        public string? OriginalFileNameFromClothingItemId(int clothingItemId)
            => _dbContext.ImageLocations.FirstOrDefault(loc => loc.ClothingItemId == clothingItemId)?.OriginalFilename;

        public (ExecutionStatus status, FileStream? file) FindImageByClothingItemId(int clothingItemId) =>
            FindLocationPathFromClothingItemId(clothingItemId) switch
            {
                (ExecutionStatus.SUCCESS, string path) => OriginalFileNameFromClothingItemId(clothingItemId) switch
                {
                    null => (ExecutionStatus.NOT_FOUND, null),
                    string filename => FileStreamFromPath(path, filename)
                },
                (ExecutionStatus status, _) => (status, null)
            };


        public string GetImageLocation(string filename) => Path.Combine(ImageFolder, Guid.NewGuid() + "_" + filename);


        public (ExecutionStatus status, int? id) SaveImageToDisk(IFormFile file, int id, string locationPath)
        {
            try
            {
                using (var fs = new FileStream(locationPath, FileMode.CreateNew))
                {
                    file.CopyTo(fs);
                }
            }
            catch (IOException ioEx)
            {
                return (ExecutionStatus.ALREADY_EXISTS, null);
            }
            catch (Exception ex)
            {
                return (ExecutionStatus.INTERNAL_SERVER_ERROR, null);
            }

            return (ExecutionStatus.SUCCESS, id);
        }

        public (ExecutionStatus status, int? clothingItemId) SaveImage(int clothingItemId, IFormFile file) =>
            AddImageLocationToDb(clothingItemId, file.FileName) switch
            {
                (ExecutionStatus.SUCCESS, int imageId, string filePath) => SaveImageToDisk(file, imageId, filePath),
                (ExecutionStatus status, _, _) => (status, null)
            };

    }
}
