using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Outfit
    {
        [Key]
        public int OutfitId { get; set; }
        [JsonPropertyName("clothingItemsIds")]
        public List<int> ClothingItemsIds { get; set; }


    }
}
