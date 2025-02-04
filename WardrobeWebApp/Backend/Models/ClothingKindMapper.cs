using Backend.Models.Enums;

namespace Backend.Models
{
    public class ClothingKindMapper
    {
        public static Dictionary<ClothingCategory, ClothingKind> ClothingDict = new()
        {
            {ClothingCategory.TShirt, ClothingKind.Top},
            {ClothingCategory.Shirt, ClothingKind.Top },
            {ClothingCategory.Blouse, ClothingKind.Top},
            {ClothingCategory.Jumper, ClothingKind.Outer},
            {ClothingCategory.Coat, ClothingKind.Overall},
            {ClothingCategory.Skirt, ClothingKind.Bottom},
            {ClothingCategory.Trousers, ClothingKind.Bottom },
            {ClothingCategory.Sari, ClothingKind.Single },
            {ClothingCategory.Dress, ClothingKind.Single },
            {ClothingCategory.Dungaree, ClothingKind.Bottom}
        };

        public static ClothingKind GetClothingKind(ClothingCategory category)
        {
            return ClothingDict[category];
        }

    
    }
}
//top + bottom +- jumper +-coat
//single  +- jumper +-coat

//1. generate two piece or one piece outfit
//2. generate random selection 
//3. weather: coat for rain? layering for different temps