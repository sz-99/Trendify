using Backend.Models.Enums;
using Backend.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace Backend.DBContext
{
    public class DatabaseSeeding
    {
        public static void SeedDatabase(WardrobeDBContext context)
        {
            if (!context.ClothingItems.Any())
            {
                context.ClothingItems.AddRange(
                    new Models.ClothingItem()
                    { Id = 1, ImageId = 1, UserId = 1, Name = "My Blue Shirt", Brand = "Hugo Boss", Category = Models.Enums.ClothingCategory.Shirt, Colour = "#A5D4DC", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Summer, Size = Models.Enums.ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 2, ImageId = 2, UserId = 1, Name = "My Black Trousers", Brand = "Marks & Spencers", Category = Models.Enums.ClothingCategory.Trousers, Colour = "#010101", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Winter, Size = Models.Enums.ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 3, ImageId = 3, UserId = 2, Name = "My Red Jacket", Brand = "Supreme", Category = Models.Enums.ClothingCategory.Coat, Colour = "#C90505", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Winter, Size = Models.Enums.ClothingSize.M },
                     new Models.ClothingItem()
                     { Id = 4, ImageId = 1, UserId = 1, Name = "My Blue Shirt", Brand = "Hugo Boss", Category = Models.Enums.ClothingCategory.Shirt, Colour = "#A5D4DC", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Summer, Size = Models.Enums.ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 5, ImageId = 2, UserId = 1, Name = "My Knit Jumper", Brand = "Marks & Spencers", Category = Models.Enums.ClothingCategory.Jumper, Colour = "#010101", Occasion = Models.Enums.Occasion.DIY, Season = Models.Enums.Season.Winter, Size = Models.Enums.ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 6, ImageId = 3, UserId = 2, Name = "Short Velvet Dungaree ", Brand = "Supreme", Category = Models.Enums.ClothingCategory.Dungaree, Colour = "#C90505", Occasion = Models.Enums.Occasion.Home, Season = Models.Enums.Season.Summer, Size = Models.Enums.ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 7, ImageId = 3, UserId = 2, Name = "My Denim Dungaree", Brand = "Levi's", Category = Models.Enums.ClothingCategory.Dungaree, Colour = "#C90505", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Winter, Size = Models.Enums.ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 8, ImageId = 3, UserId = 2, Name = "My Expensive Cashmere Coat", Brand = "MaxMara", Category = Models.Enums.ClothingCategory.Coat, Colour = "#C90505", Occasion = Models.Enums.Occasion.Party, Season = Models.Enums.Season.Winter, Size = Models.Enums.ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 9, ImageId = 7, UserId = 5, Name = "Flare Skirt", Brand = "Dries Van Noten", Category = Models.Enums.ClothingCategory.Skirt, Colour = "#C90505", Occasion = Models.Enums.Occasion.Party, Season = Models.Enums.Season.Autumn, Size = Models.Enums.ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 10, ImageId = 11, UserId = 1, Name = "My Wool Blend Jumper", Brand = "Marks & Spencers", Category = Models.Enums.ClothingCategory.Jumper, Colour = "#010101", Occasion = Models.Enums.Occasion.DIY, Season = Models.Enums.Season.Winter, Size = Models.Enums.ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 11, ImageId = 2, UserId = 1, Name = "Bling bling Sari", Brand = "Made by Me", Category = Models.Enums.ClothingCategory.Sari, Colour = "#010101", Occasion = Models.Enums.Occasion.DIY, Season = Models.Enums.Season.Spring, Size = Models.Enums.ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 12, ImageId = 2, UserId = 1, Name = "mini sparkly dress", Brand = "urban outfitters", Category = Models.Enums.ClothingCategory.Dress, Colour = "#010101", Occasion = Models.Enums.Occasion.DIY, Season = Models.Enums.Season.Summer, Size = Models.Enums.ClothingSize.M }
                    );
                context.SaveChanges();
            }

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
    }
}
