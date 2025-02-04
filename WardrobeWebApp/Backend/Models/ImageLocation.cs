using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class ImageLocation
    {
        [Key] 
        public int Id { get; set; }

        public string? Location { get; set; } = null;

        public ImageLocation(string location)
        {
            Location = location.Trim();
        }
    }
}
