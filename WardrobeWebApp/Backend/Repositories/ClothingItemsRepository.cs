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
        public ClothingItem? ReplaceClothingItem(ClothingItem clothingWithNewValues)
        {
            _dbContext.ClothingItems.Update(clothingWithNewValues);
            _dbContext.SaveChanges();

            return clothingWithNewValues;
        }
        public void DeleteClothingItem(ClothingItem clothingItem)
        {
            _dbContext.ClothingItems.Remove(clothingItem);
            _dbContext.SaveChanges();
        }
        public List<ClothingItem> FindAllClothingItems()
        {
            return _dbContext.ClothingItems
                            //.Include(clothingItem => clothingItem.Colour)
                            .ToList();
        }

        public ClothingItem? FindClothingItemById(int id)
        {
            return _dbContext.ClothingItems
                                         //.Include(clothingItem => clothingItem.Colour)
                                         .FirstOrDefault(clothingItem => clothingItem.Id == id);
        }
        public List<ClothingItem> FindClothingItemByBrand(string brand)
        {
            return _dbContext.ClothingItems
                                         .Where(clothingItem => clothingItem.Brand == brand)
                                         .ToList();

        }
        public List<ClothingItem> FindClothingItemByOccation(int occationId)
        {
            return _dbContext.ClothingItems
                                         .Where(clothingItem => (int)clothingItem.Occasion == occationId)
                                         .ToList();

        }
        public List<ClothingItem> FindClothingItemBySeason(int seasonId)
        {
            return _dbContext.ClothingItems
                                         .Where(clothingItem => (int)clothingItem.Season == seasonId)
                                         .ToList();

        }
        public List<ClothingItem> FindClothingItemBySize(int size)
        {
            return _dbContext.ClothingItems
                                         .Where(clothingItem => (int)clothingItem.Size == size)
                                         .ToList();        
        }
    }
}
