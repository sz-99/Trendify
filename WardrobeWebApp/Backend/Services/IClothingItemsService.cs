using Backend.Models;
using Backend.Models.Enums;

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
