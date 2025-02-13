using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class ImageUrl
    {
        [Key]
        public int ImageId { get; set; }
        [Required]
        public string? Url { get; set; } = string.Empty;
    }
}
