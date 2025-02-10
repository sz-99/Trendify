using Backend.Models;
using Backend.Models.Enums;

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
                    { ImageId = 1, UserId = 1, Name = "Black Oversized Jumper", Brand = "Y/Project", Category = ClothingCategory.Jumper, Colour = "Black", Occasion = Occasion.Home, Season = Season.Autumn, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { ImageId = 2, UserId = 1, Name = "Asymmetrical Black Skirt", Brand = "Unknown", Category = ClothingCategory.Skirt, Colour = "Black", Occasion = Occasion.Evening, Season = Season.Summer, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { ImageId = 3, UserId = 2, Name = "Blue Faux Leather Jacket", Brand = "Wilfred", Category = ClothingCategory.Jumper, Colour = "Blue", Occasion = Occasion.Party, Season = Season.Spring, Size = ClothingSize.L },
                    new Models.ClothingItem()
                    { ImageId = 4, UserId = 1, Name = "Herringbone Bias-Cut Skirt", Brand = "M&S", Category = ClothingCategory.Skirt, Colour = "Brown", Occasion = Occasion.Party, Season = Season.Winter, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { ImageId = 5, UserId = 1, Name = "Straight-Leg Grey Jeans", Brand = "& Other Stories", Category = ClothingCategory.Trousers, Colour = "Dark Grey", Occasion = Occasion.Home, Season = Season.Autumn, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { ImageId = 6, UserId = 2, Name = "Denim Corset Top w/ Back Zip", Brand = "Aritzia", Category = ClothingCategory.Blouse, Colour = "Blue", Occasion = Occasion.DIY, Season = Season.Summer, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { ImageId = 7, UserId = 2, Name = "Double-Breasted Coat w/ Belt and Button Stand Collar", Brand = "Calvin Klein", Category = ClothingCategory.Coat, Colour = "Grey", Occasion = Occasion.Formal, Season = Season.Winter, Size = ClothingSize.S },
                    new Models.ClothingItem()
                    { ImageId = 8, UserId = 2, Name = "Long-Sleeve Cotton Dungaree", Brand = "COS", Category = ClothingCategory.Dungaree, Colour = "Navy", Occasion = Occasion.Sport, Season = Season.Autumn, Size = ClothingSize.S },
                    new Models.ClothingItem()
                    { ImageId = 9, UserId = 2, Name = "Cashmere V-Neck Cardigan", Brand = "COS", Category = ClothingCategory.Jumper, Colour = "Dark Grey", Occasion = Occasion.DIY, Season = Season.Winter, Size = ClothingSize.L },
                    new Models.ClothingItem()
                    { ImageId = 10, UserId = 2, Name = "Waterproof Coat w/ Removable Down Layer", Brand = "The North Face", Category = ClothingCategory.Coat, Colour = "Black", Occasion = Occasion.Sport, Season = Season.Winter, Size = ClothingSize.XL },
                    new Models.ClothingItem()
                    { ImageId = 11, UserId = 2, Name = "Off-The-Shoulder Crop Top", Brand = "Wilfred", Category = ClothingCategory.Shirt, Colour = "Light Blue", Occasion = Occasion.DIY, Season = Season.Spring, Size = ClothingSize.S },
                    new Models.ClothingItem()
                    { ImageId = 12, UserId = 2, Name = "Stripe Off-The-Shoulder Top", Brand = "Unknown", Category = ClothingCategory.TShirt, Colour = "Black", Occasion = Occasion.Evening, Season = Season.Summer, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { ImageId = 13, UserId = 2, Name = "High-Waisted Trousers w/ Matching Belt", Brand = "Topshop", Category = ClothingCategory.Trousers, Colour = "Dark Grey", Occasion = Occasion.Home, Season = Season.Autumn, Size = ClothingSize.L }
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
                        new ImageLocation(null, @".\Resources\Images\BlackJumper.jpg.jpg", "BlackJumper.jpg.jpg"),
                        new ImageLocation(null, @".\Resources\Images\blackSkirt.jpg.jpg", "blackSkirt.jpg.jpg"),
                        new ImageLocation(null, @".\Resources\Images\BlueJacket.jpg.jpg", "BlueJacket.jpg.jpg"),
                        new ImageLocation(null, @".\Resources\Images\BrownSkirt.jpg.jpg", "BrownSkirt.jpg.jpg"),
                        new ImageLocation(null, @".\Resources\Images\DarkGreyJeans.jpg.jpg", "DarkGreyJeans.jpg.jpg"),
                        new ImageLocation(null, @".\Resources\Images\DenimTop.jpg.jpg", "DenimTop.jpg.jpg"),
                        new ImageLocation(null, @".\Resources\Images\GreyCoat.jpg.jpg", "GreyCoat.jpg.jpg"),
                        new ImageLocation(null, @".\Resources\Images\NavyDungaree.jpg.jpg", "NavyDungaree.jpg.jpg"),
                        new ImageLocation(null, @".\Resources\Images\GreyCardigan.jpg.jpg", "GreyCardigan.jpg.jpg"), 
                        new ImageLocation(null, @".\Resources\Images\NorthFaceCoat.jpg.jpg", "NorthFaceCoat.jpg.jpg"), 
                        new ImageLocation(null, @".\Resources\Images\OffTheShoulderTop.jpg.jpg", "OffTheShoulderTop.jpg.jpg"), 
                        new ImageLocation(null, @".\Resources\Images\StripeTop.jpg.jpg", "StripeTop.jpg.jpg"),
                        new ImageLocation(null, @".\Resources\Images\TieWaistTrousers.jpg.jpg", "TieWaistTrousers.jpg.jpg"), 
                        new ImageLocation(null, @".\Resources\Images\WhiteDress.jpg.jpg", "WhiteDress.jpg.jpg"),
                        new ImageLocation(null, @".\Resources\Images\WhiteTrousers.jpg.jpg", "WhiteTrousers.jpg.jpg")







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
