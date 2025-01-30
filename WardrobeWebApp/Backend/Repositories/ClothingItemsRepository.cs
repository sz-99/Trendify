using Backend;
using Backend.Models;

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
            return _dbContext.ClothingItems.ToList();
        }

        public ClothingItem? FindClothingItemById(int id)
        {
            var clothingItem = FindAllClothingItems().FirstOrDefault(item => item.Id == id);
            return clothingItem;
        }
    }
}
