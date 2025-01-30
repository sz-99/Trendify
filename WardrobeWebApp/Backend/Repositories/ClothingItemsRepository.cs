using Backend;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class ClothingItemsRepository : IClothingItemsRepository
    {
        WardrobeDBContext _dbContext;
        public ClothingItemsRepository(WardrobeDBContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public ClothingItem? AddClothingItem(ClothingItem clothingItem)
        {
            _dbContext.ClothingItems.Add(clothingItem);
            _dbContext.SaveChanges();
            return clothingItem;
        }

        public List<ClothingItem> FindAllClothingItems()
        {
            return _dbContext.ClothingItems
                            //.Include(clothingItem => clothingItem.Colour)
                            .ToList();
        }

        public ClothingItem? FindClothingItemById(int id)
        {
            var clothingItem = _dbContext.ClothingItems
                                         //.Include(clothingItem => clothingItem.Colour)
                                         .FirstOrDefault(clothingItem => clothingItem.Id == id);
            return clothingItem;
        }
    }
}
