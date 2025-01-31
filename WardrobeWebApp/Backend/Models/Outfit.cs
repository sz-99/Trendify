using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Outfit
    {
        [Key]
        public int OutfitId { get; set; }

        public List<int> ClothingItemsIds { get; set; }


    }
}
