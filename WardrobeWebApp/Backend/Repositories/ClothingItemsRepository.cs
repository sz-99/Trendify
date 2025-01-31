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

        public List<ClothingItem> FindFilteredClothingItems(ClothingItemFilter filter)
        {
            var query = _dbContext.ClothingItems.AsQueryable();

  
            if (filter.Category.HasValue)
                query = query.Where(c => (int)c.Category == filter.Category.Value);

            if (filter.Size.HasValue)
                query = query.Where(c => (int)c.Size == filter.Size.Value);

            if (!string.IsNullOrEmpty(filter.Brand))
                query = query.Where(c => c.Brand == filter.Brand);

            if (!string.IsNullOrEmpty(filter.Colour))
                query = query.Where(c => c.Colour == filter.Colour);

            if (filter.Occasion.HasValue)
                query = query.Where(c => (int)c.Occasion == filter.Occasion.Value);

            if (filter.Season.HasValue)
                query = query.Where(c => (int)c.Season == filter.Season.Value);


            return  query.ToList();
        }

        public List<ClothingItem> FindClothingItemByCategory(int category)
        {
            return _dbContext.ClothingItems
                                         .Where(clothingItem => (int)clothingItem.Category == category)
                                         .ToList();

        }
        public List<ClothingItem> FindClothingItemByBrand(string brand)
        {
            return _dbContext.ClothingItems
                                         .Where(clothingItem => clothingItem.Brand == brand)
                                         .ToList();

        }
        public List<ClothingItem> FindClothingItemByOccasion(int occasionId)
        {
            return _dbContext.ClothingItems
                                         .Where(clothingItem => (int)clothingItem.Occasion == occasionId)
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
