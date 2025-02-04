using Backend.Models;
using Backend.Models.Enums;

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

        public (ExecutionStatus status, int? id, string? location) AddImageLocationToDb(string filename)
        {
            try
            {
                var locationPath = GetImageLocation(filename);
                var imageLocation = new ImageLocation(locationPath);
                _dbContext.ImageLocations.Add(imageLocation);
                return (ExecutionStatus.SUCCESS, imageLocation.Id, locationPath);
            }
            catch 
            {
                return (ExecutionStatus.INTERNAL_SERVER_ERROR, null, null);
            }   
        }

        public string GetImageLocation(string filename) => Path.Combine(ImageFolder, filename);  
        

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

        public (ExecutionStatus status, int? id) SaveImage(IFormFile file) => AddImageLocationToDb(file.FileName) switch
        {
            (ExecutionStatus.SUCCESS, int id, string location) => SaveImageToDisk(file, id, location),
            (ExecutionStatus status, _, _) => (status, null)
        };

    }
}
