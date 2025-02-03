namespace Backend.Services
{
    public class ImageService : IImageService
    {
        string ImageFolder { get; set; } = @".\Resources\Images\";
        public ImageService() { }

        public int SaveImage(string filename, IFormFile file)
        {

            using (var fs = new FileStream(ImageFolder + filename, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            return 1;

        }
    }
}
