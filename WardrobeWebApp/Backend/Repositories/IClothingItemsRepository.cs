using Backend.Models;

namespace Backend
{
    public interface IClothingItemsRepository
    {
        List<ClothingItem> FindAllClothingItems();

        ClothingItem? AddClothingItem(ClothingItem clothingItem);


        ClothingItem? FindClothingItemById(int id);
        ClothingItem? ReplaceClothingItem(ClothingItem clothingItem);
        void DeleteClothingItem(ClothingItem clothingItem);

    }
}
