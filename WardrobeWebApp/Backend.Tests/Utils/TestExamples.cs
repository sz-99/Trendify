using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;
using Backend.Models;
using Backend.Models.Enums;

namespace Backend.Tests
{
    internal class TestExamples
    {
        public static ClothingItem GetInitialClothingItem() => 
            new ClothingItem()
            {
                Id = 1,
                UserId = 1,
                ImageId = 1,
                Name = "White T-shirt",
                Category = ClothingCategory.TShirt,
                Size = ClothingSize.M,
                Brand = "Fantastic T-shirts",
                Colour = "Blue",
                Occasion = Occasion.Sport,
                Season = Season.Summer
            };

        public static ClothingItem GetADifferentClothingItem() =>
            new ClothingItem()
            {
                Id = 2,
                UserId = 2,
                ImageId = 2,
                Name = "Pink shirt",
                Category = ClothingCategory.Shirt,
                Size = ClothingSize.L,
                Brand = "Amazing Shirts",
                Colour = "Pink",
                Occasion = Occasion.Evening,
                Season = Season.Winter
            };

        public static List<ClothingItem> GetListOfClothingItem()
        {
            return new List<ClothingItem>()
            {
                new Models.ClothingItem()
                    { Id = 1, ImageId = 1, UserId = 1, Name = "My Blue Shirt", Brand = "Hugo Boss", Category = Models.Enums.ClothingCategory.Shirt, Colour = "#A5D4DC", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Summer, Size = Models.Enums.ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 2, ImageId = 2, UserId = 1, Name = "My Black Trousers", Brand = "Marks & Spencers", Category = Models.Enums.ClothingCategory.Trousers, Colour = "#010101", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Winter, Size = Models.Enums.ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 3, ImageId = 3, UserId = 2, Name = "My Red Jacket", Brand = "Supreme", Category = Models.Enums.ClothingCategory.Coat, Colour = "#C90505", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Winter, Size = Models.Enums.ClothingSize.M },
                     new Models.ClothingItem()
                     { Id = 4, ImageId = 1, UserId = 1, Name = "My Blue Shirt", Brand = "Hugo Boss", Category = Models.Enums.ClothingCategory.Shirt, Colour = "#A5D4DC", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Summer, Size = Models.Enums.ClothingSize.M},
                    new Models.ClothingItem()
                    { Id = 5, ImageId = 2, UserId = 1, Name = "My Black Trousers", Brand = "Marks & Spencers", Category = Models.Enums.ClothingCategory.Trousers, Colour = "#010101", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Winter, Size = Models.Enums.ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 6, ImageId = 3, UserId = 2, Name = "My Red Jacket", Brand = "Supreme", Category = Models.Enums.ClothingCategory.Coat, Colour = "#C90505", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Winter, Size = Models.Enums.ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 7, ImageId = 3, UserId = 2, Name = "My Blue Dress", Brand = "Supreme", Category = Models.Enums.ClothingCategory.Dress, Colour = "#C90505", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Winter, Size = Models.Enums.ClothingSize.M },
                    new Models.ClothingItem()
                    { Id = 8, ImageId = 3, UserId = 2, Name = "My Purple Sari", Brand = "Supreme", Category = Models.Enums.ClothingCategory.Sari, Colour = "#C90505", Occasion = Models.Enums.Occasion.Formal, Season = Models.Enums.Season.Winter, Size = Models.Enums.ClothingSize.M }
            };
        }
    }
        
}

