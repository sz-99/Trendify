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
                    { Id = 1, ImageId = 1, UserId = 1, Name = "My Blue Shirt", Brand = "Hugo Boss", Category = Models.Enums.ClothingCategory.Shirt, Colour = "#A5D4DC", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Summer, Size = Models.Enums.ClothingSize.M},
                    new Models.ClothingItem() 
                    { Id = 2, ImageId = 2, UserId = 1, Name = "My Black Trousers", Brand = "Marks & Spencers", Category = Models.Enums.ClothingCategory.Trousers, Colour = "#010101", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Winter, Size = Models.Enums.ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 3, ImageId = 3, UserId = 2, Name = "My Red Jacket", Brand = "Supreme", Category = Models.Enums.ClothingCategory.Coat, Colour = "#C90505", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Winter, Size = Models.Enums.ClothingSize.M },
                     new Models.ClothingItem() 
                     { Id = 4, ImageId = 1, UserId = 1, Name = "My Blue Shirt", Brand = "Hugo Boss", Category = Models.Enums.ClothingCategory.Shirt, Colour = "#A5D4DC", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Summer, Size = Models.Enums.ClothingSize.M},
                    new Models.ClothingItem()
                    { Id = 5, ImageId = 2, UserId = 1, Name = "My Black Trousers", Brand = "Marks & Spencers", Category = Models.Enums.ClothingCategory.Trousers, Colour = "#010101", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Winter, Size = Models.Enums.ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 6, ImageId = 3, UserId = 2, Name = "My Red Jacket", Brand = "Supreme", Category = Models.Enums.ClothingCategory.Coat, Colour = "#C90505", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Winter, Size = Models.Enums.ClothingSize.M }
                    );
                context.SaveChanges();
            }
        }
    }
}
