using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Models.Enums;

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
        public ExecutionStatus DeleteClothingItem(int id)
        {
            try
            {
                var clothingItemToDelete = _repository.FindClothingItemById(id);
                if (clothingItemToDelete != null)
                {
                    _repository.DeleteClothingItem(clothingItemToDelete);
                    return ExecutionStatus.SUCCESS;
                }
                return ExecutionStatus.NOT_FOUND;
            }
            catch (Exception ex)
            {
                return ExecutionStatus.INTERNAL_SERVER_ERROR;
            }
        }
        public (ExecutionStatus status, ClothingItem updatedClothingItem) ReplaceClothingItem(int id, ClothingItem clothingItem) 
        {
            try
            {
                var clothingItemToUpdate = _repository.FindClothingItemById(id);

                if (clothingItemToUpdate == null)
                    return (ExecutionStatus.NOT_FOUND, null);

                clothingItemToUpdate.UpdateWithValuesFrom(clothingItem);

                var updatedClothingItem = _repository.ReplaceClothingItem(clothingItemToUpdate);

                return (ExecutionStatus.SUCCESS, updatedClothingItem);

            }
            catch (Exception ex)
            {

                return (ExecutionStatus.INTERNAL_SERVER_ERROR, null);
            }
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
