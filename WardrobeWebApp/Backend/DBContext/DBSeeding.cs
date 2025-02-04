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
                    { Id = 1, ImageId = 1, UserId = 1, Name = "My Blue Shirt", Brand = "Hugo Boss", Category = ClothingCategory.Shirt, Colour = "#A5D4DC", Occasion = Occasion.Formal, Season = Season.Summer, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 2, ImageId = 2, UserId = 1, Name = "My Black Trousers", Brand = "Marks & Spencers", Category = ClothingCategory.Trousers, Colour = "#010101", Occasion = Occasion.Formal, Season = Season.Winter, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 3, ImageId = 3, UserId = 2, Name = "My Red Jacket", Brand = "Supreme", Category = ClothingCategory.Coat, Colour = "#C90505", Occasion = Occasion.Formal, Season = Season.Winter, Size = ClothingSize.M },
                     new Models.ClothingItem() 
                     { Id = 4, ImageId = 1, UserId = 1, Name = "My Blue Shirt", Brand = "Hugo Boss", Category = ClothingCategory.Shirt, Colour = "#A5D4DC", Occasion = Occasion.Formal, Season = Season.Summer, Size = ClothingSize.M},
                    new Models.ClothingItem()
                    { Id = 5, ImageId = 2, UserId = 1, Name = "My Black Trousers", Brand = "Marks & Spencers", Category = ClothingCategory.Trousers, Colour = "#010101", Occasion = Occasion.Formal, Season = Season.Winter, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 6, ImageId = 3, UserId = 2, Name = "My Red Jacket", Brand = "Supreme", Category = ClothingCategory.Coat, Colour = "#C90505", Occasion = Occasion.Formal, Season = Season.Winter, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 7, ImageId = 3, UserId = 2, Name = "My Blue Dress", Brand = "Supreme", Category = ClothingCategory.Dress, Colour = "#C90505", Occasion = Occasion.Formal, Season = Season.Winter, Size = ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 8, ImageId = 3, UserId = 2, Name = "My Purple Sari", Brand = "Supreme", Category = ClothingCategory.Sari, Colour = "#C90505", Occasion = Occasion.Formal, Season = Season.Winter, Size = ClothingSize.M }
                    );
                context.SaveChanges();
            }
        }
    }
}
