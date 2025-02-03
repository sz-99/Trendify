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

        /// <summary>
        /// Takes an Id and a clothing Item. Finds the item with Id id, and replaces with the values
        /// in clothingItem. Updates the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="replacementClothingItem"></param>
        /// <returns></returns>
        public (ExecutionStatus status, ClothingItem updatedClothingItem) ReplaceClothingItem(int id, ClothingItem replacementClothingItem) 
        {
            try
            {
                var clothingItemToUpdate = _repository.FindClothingItemById(id);

                if (clothingItemToUpdate == null)
                    return (ExecutionStatus.NOT_FOUND, null);

                var updated = clothingItemToUpdate.UpdateWithValuesFrom(replacementClothingItem);

                var updatedClothingItem = _repository.ReplaceClothingItem(updated);

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
