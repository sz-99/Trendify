using Backend.Models.Enums;
using System.Drawing;

namespace Backend.Models
{
    public class ClothingItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int ImageId { get; set; }
        public string Name { get; set; }

        public ClothingCategory Category { get; set; }

        public ClothingSize Size { get; set; }

        public string Brand { get; set; }
        public List<Color> Colours { get; set; }

        public Occasion Occasion { get; set; }

    }
}
