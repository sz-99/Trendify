using Backend.Models.Enums;
using Backend.Models;

namespace Backend.DBContext
{
    public class DatabaseSeeding
    {
        public static void SeedClothingItems(WardrobeDBContext context)
        {
            if (!context.ClothingItems.Any())
            {
                context.ClothingItems.AddRange(
                    new Models.ClothingItem()
                    { ImageId = 1, UserId = 1, Name = "My Black trousers", Brand = "Hugo Boss", Category = ClothingCategory.Trousers, Colour = "Black", Occasion = Occasion.Home, Season = Season.Autumn, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { ImageId = 2, UserId = 1, Name = "My Black Shirt", Brand = "Nike", Category = ClothingCategory.Shirt, Colour = "Black", Occasion = Occasion.Home, Season = Season.Summer, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { ImageId = 3, UserId = 2, Name = "My Hoodie", Brand = "Supreme", Category = ClothingCategory.Jumper, Colour = "Black", Occasion = Occasion.Sport, Season = Season.Winter, Size = ClothingSize.L },
                    new Models.ClothingItem()
                    { ImageId = 4, UserId = 1, Name = "My Pink Frock", Brand = "Hugo Boss", Category = ClothingCategory.Dress, Colour = "Pink", Occasion = Occasion.Party, Season = Season.Summer, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { ImageId = 5, UserId = 1, Name = "My Brown PoloShirt", Brand = "Marks & Spencers", Category = ClothingCategory.Shirt, Colour = "Brown", Occasion = Occasion.DIY, Season = Season.Winter, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { ImageId = 6, UserId = 2, Name = "Yellow and white poloshirt", Brand = "Supreme", Category = ClothingCategory.Shirt, Colour = "Yellow", Occasion = Occasion.Home, Season = Season.Summer, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { ImageId = 7, UserId = 2, Name = "Rain Jacket", Brand = "Levi's", Category = ClothingCategory.Coat, Colour = "Blue", Occasion = Occasion.Sport, Season = Season.Winter, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { ImageId = 8, UserId = 2, Name = "SPorts T-shirt", Brand = "MaxMara", Category = ClothingCategory.Coat, Colour = "Orange", Occasion = Occasion.Sport, Season = Season.Winter, Size = ClothingSize.M }
                    );
                context.SaveChanges();
            }
        }

        public static void SeedLogins(WardrobeDBContext context)
        {
            if (!context.UserLogins.Any())
            {
                context.UserLogins.AddRange(
                     new UserLogin() { UserId = 1, UserName = "testuser1@wardrobe.com", Password = "helloworld" },
                     new UserLogin() { UserId = 2, UserName = "testuser2@wardrobe.com", Password = "goodbyeworld" },
                     new UserLogin() { UserId = 3, UserName = "testuser3@wardrobe.com", Password = "hello" },
                     new UserLogin() { UserId = 4, UserName = "testuser4@wardrobe.com", Password = "password" }
                );
                context.SaveChanges();
            }
        }

        public static void SeedImageLocations(WardrobeDBContext context)
        {
            if (!context.ImageLocations.Any())
            {
                context.ImageLocations.AddRange(
                    new ImageLocation(null, @".\Resources\Images\BlackPant.jpg", "BlackPant.jpg"),
                    new ImageLocation(null, @".\Resources\Images\blacktshirtnike.jpg", "blacktshirtnike.jpg"),
                    new ImageLocation(null, @".\Resources\Images\Hoodie.jpg", "Hoodie.jpg"),
                    new ImageLocation(null, @".\Resources\Images\pinkfrock-sleeveless.jpg", "pinkfrock-sleeveless.jpg"),
                    new ImageLocation(null, @".\Resources\Images\PoloBrown.jpg", "PoloBrown.jpg"),
                    new ImageLocation(null, @".\Resources\Images\PoloYellowwhite.jpg", "PoloYellowwhite.jpg"),
                    new ImageLocation(null, @".\Resources\Images\RainJacket.jpg", "RainJacket.jpg"),
                    new ImageLocation(null, @".\Resources\Images\tshirt-sports.jpg", "tshirt-sports.jpg")
                );
                context.SaveChanges();
            };
        }

        public static void SeedDatabase(WardrobeDBContext context)
        {
            SeedClothingItems(context);
            SeedImageLocations(context);
            SeedLogins(context);
        }
    }
}
