using Backend.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class ClothingItem
    {

        public int Id { get; set; }
        public int UserId { get; set; }

        public int ImageId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        [EnumDataType(typeof(ClothingCategory))]
        public ClothingCategory Category { get; set; }
        [EnumDataType(typeof(ClothingSize))]
        public ClothingSize Size { get; set; }

        [JsonPropertyName("brand")]
        public string Brand { get; set; }
        //public List<Colour> Colours { get; set; }
        //public Color Colour { get; set; }

        [JsonPropertyName("colour")]
        public string Colour { get; set; }
        [EnumDataType(typeof(Occasion))]
        public Occasion Occasion { get; set; }
        [EnumDataType(typeof(Season))]
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
