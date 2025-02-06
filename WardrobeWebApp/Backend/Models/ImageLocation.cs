using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class ImageLocation
    {
        [Key] 
        public int Id { get; set; }

        public int? ClothingItemId { get; set; }

        public string? LocationPath { get; set; } = null;

        public string? OriginalFilename { get; set; } = null;

        public ImageLocation(int? clothingItemId, string locationPath, string originalFilename)
        {
            ClothingItemId = clothingItemId;
            LocationPath = locationPath.Trim();
            OriginalFilename = originalFilename;
        }
    }
}
