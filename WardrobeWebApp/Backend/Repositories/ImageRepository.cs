namespace Backend
{
    public class ImageRepository : IImageRepository
    {
        string ImageFolder { get; set; } = @".\Resources\Images\";
        public ImageRepository() { }

        public int GetNextImageId()
        {
            return 1;
        }

        public int SaveImage(IFormFile file)
        {
            var id = GetNextImageId();
            using (var fs = new FileStream(ImageFolder + id.ToString() + ".png", FileMode.Create))
            {
                file.CopyTo(fs);
            }

            return id;
        }
    }
}
