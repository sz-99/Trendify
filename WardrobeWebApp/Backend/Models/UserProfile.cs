using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Backend.Models
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }

        public List<Colour> FavouriteColours { get; set; }

        //public Color FavouriteColour { get; set; }
    }
}
