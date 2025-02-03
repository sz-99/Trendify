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
                Id = 0,
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
                Id = 0,
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
    }
        
}

