using Backend.Models;

namespace Backend
{
    public interface IClothingItemsService
    {
        ClothingItem? AddClothingItem(ClothingItem clothingItem);
        List<ClothingItem> FindAllClothingItems();
        ClothingItem? FindClothingItemById(int id);
    }
}
