using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class ClothingItemsService : IClothingItemsService
    {
        private IClothingItemsRepository _repository;
        public ClothingItemsService(IClothingItemsRepository repository)
        {
            _repository = repository;
        }

        public ClothingItem? AddClothingItem(ClothingItem clothingItem)
        {
            return _repository.AddClothingItem(clothingItem);
        }

        public List<ClothingItem> FindAllClothingItems()
        {
            return _repository.FindAllClothingItems();
        }

        public ClothingItem? FindClothingItemById(int id)
        {
            return _repository.FindClothingItemById(id);
        }
    }
}
