using System.Drawing;

namespace Backend.Models
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public string Name { get; set; }
       
        public List<Color> FavouriteColours {  get; set; } 

    }
}
