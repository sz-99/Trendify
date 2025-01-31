using Backend.Models;
using RecordShop.Model;

namespace Backend
{
    public interface IClothingItemsService
    {
        ClothingItem? AddClothingItem(ClothingItem clothingItem);
        List<ClothingItem> FindAllClothingItems();
        ClothingItem? FindClothingItemById(int id);
        ExecutionStatus DeleteClothingItem(int id);
        (ExecutionStatus status, ClothingItem updatedClothingItem) ReplaceClothingItem(int id, ClothingItem clothingItem);
    }
}
