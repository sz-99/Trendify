using Backend.Models.Enums;
using Backend.Models.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Backend.Models
{
    public class ClothingItem
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required]
        [JsonPropertyName("imageId")]
        public int ImageId { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(ClothingCategory))]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("category")]
        public ClothingCategory Category { get; set; }

        [EnumDataType(typeof(ClothingSize))]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("size")]
        public ClothingSize Size { get; set; }

        [JsonPropertyName("brand")]
        public string? Brand { get; set; }

        [Required]
        [JsonPropertyName("colour")]

        public string Colour { get; set; }

        [EnumDataType(typeof(Occasion))]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("occasion")]
        public Occasion Occasion { get; set; }
        [EnumDataType(typeof(Season))]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("season")]
        public Season Season { get; set; }

        public static ClothingItem Copy(ClothingItem other)
        {
            var clothingItem = new ClothingItem();
            clothingItem.Id = other.Id;
            clothingItem.UpdateWithValuesFrom(other);
            return clothingItem;
        }


        /// <summary>
        /// Copy all values apart from Id
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public ClothingItem UpdateWithValuesFrom(ClothingItem other)
        {
            this.UserId = other.UserId;
            this.ImageId = other.ImageId;
            this.Name = other.Name;
            this.Category = other.Category;
            this.Size = other.Size;
            this.Brand = other.Brand;
            this.Colour = other.Colour;
            this.Occasion = other.Occasion;
            this.Season = other.Season;

            return this;
        }

        public bool HasSameValuesAs(ClothingItem other)
        {
            return  this.UserId == other.UserId &&
                    this.ImageId == other.ImageId &&
                    this.Name == other.Name &&
                    this.Category == other.Category &&
                    this.Size == other.Size &&
                    this.Brand == other.Brand &&
                    this.Colour == other.Colour &&
                    this.Occasion == other.Occasion &&
                    this.Season == other.Season;
        }
    }
}
