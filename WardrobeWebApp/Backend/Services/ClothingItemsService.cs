using Microsoft.EntityFrameworkCore;
using Backend.Models.Enums;
using Backend.Models;

//using ClothingItemResult = (Backend.Models.Enums.ExecutionStatus Status, List<ClothingItem> Items);
namespace Backend
{
    public class ClothingItemsService : IClothingItemsService
    {
        private IClothingItemsRepository _repository;
        public ClothingItemsService(IClothingItemsRepository repository)
        {
            _repository = repository;
        }

        public (ExecutionStatus status, ClothingItem newClothingItem) AddClothingItem(ClothingItem clothingItem)
        {
            try
            {                
                ClothingItem newClothingItem= _repository.AddClothingItem(clothingItem); 
                return (ExecutionStatus.SUCCESS, newClothingItem);
            }
            catch (Exception ex)
            {
                return (ExecutionStatus.INTERNAL_SERVER_ERROR, null);
            }
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
        public (ExecutionStatus status, List<ClothingItem> clothingItems) FindAllClothingItems()
        {
            try
            {
                var clothingItems = _repository.FindAllClothingItems();
                if (clothingItems == null)
                {
                    return (ExecutionStatus.NOT_FOUND, null);
                }

                return (ExecutionStatus.SUCCESS, clothingItems);
            }
            catch (Exception ex)
            {
                return (ExecutionStatus.INTERNAL_SERVER_ERROR, null);
            }
        }

        public (ExecutionStatus status, ClothingItem ClothingItem) FindClothingItemById(int id)
        {
                try
                {
                    var filteredClothingItem = _repository.FindClothingItemById(id);
                    if (filteredClothingItem == null)
                    {
                        return (ExecutionStatus.NOT_FOUND, null);
                    }

                    return (ExecutionStatus.SUCCESS, filteredClothingItem);
                }
                catch (Exception ex)
                {
                    return (ExecutionStatus.INTERNAL_SERVER_ERROR, null);
                }
        }

        public (ExecutionStatus status, List<ClothingItem> clothingItems) GetFilteredClothingItems(ClothingItemFilter filter)
        {
            try
            {
                var filteredClothingItems = _repository.FindFilteredClothingItems(filter);
                if (filteredClothingItems == null)
                {
                    return (ExecutionStatus.NOT_FOUND, null);
                }

                return (ExecutionStatus.SUCCESS, filteredClothingItems);
            }
            catch (Exception ex)
            {

                return (ExecutionStatus.INTERNAL_SERVER_ERROR, null);
            }

        }
/*********
        public (ExecutionStatus status, List<ClothingItem> clothingItems) FindClothingItemByCategory(int category)
        {
            try
            {
                var filteredClothingItems = _repository.FindClothingItemByCategory(category);
                if (filteredClothingItems == null)
                {
                    return (ExecutionStatus.NOT_FOUND, null);
                }

                return (ExecutionStatus.SUCCESS, filteredClothingItems);
            }
            catch (Exception ex)
            {

                return (ExecutionStatus.INTERNAL_SERVER_ERROR, null);
            }
        }
        public (ExecutionStatus status, List<ClothingItem>) FindAllClothingItemsByBrand(string brand)
        {
            try
            {
                var filteredClothingItems = _repository.FindClothingItemByBrand(brand);
                if (filteredClothingItems == null)
                {
                    return (ExecutionStatus.NOT_FOUND, null);
                }

                return (ExecutionStatus.SUCCESS, filteredClothingItems);
            }
            catch (Exception ex)
            {
                return (ExecutionStatus.INTERNAL_SERVER_ERROR, null);
            }
        }
        public (ExecutionStatus status, List<ClothingItem>) FindAllClothingItemsByOccasion(int occasion)
        {
            try
            {
                var filteredClothingItems = _repository.FindClothingItemByOccasion(occasion);
                if (filteredClothingItems == null)
                {
                    return (ExecutionStatus.NOT_FOUND, null);
                }

                return (ExecutionStatus.SUCCESS, filteredClothingItems);
            }
            catch (Exception ex)
            {
                return (ExecutionStatus.INTERNAL_SERVER_ERROR, null);
            }
        }
        public (ExecutionStatus status, List<ClothingItem>) FindAllClothingItemsBySeason(int season)
        {
            try
            {
                var filteredClothingItems = _repository.FindClothingItemBySeason(season);
                if (filteredClothingItems == null)
                {
                    return (ExecutionStatus.NOT_FOUND, null);
                }

                return (ExecutionStatus.SUCCESS, filteredClothingItems);
            }
            catch (Exception ex)
            {
                return (ExecutionStatus.INTERNAL_SERVER_ERROR, null);
            }
        }
        public (ExecutionStatus status, List<ClothingItem>) FindAllClothingItemsBySize(int size)
        {
            try
            {
                var filteredClothingItems = _repository.FindClothingItemBySize(size);
                if (filteredClothingItems == null)
                {
                    return (ExecutionStatus.NOT_FOUND, null);
                }

                return (ExecutionStatus.SUCCESS, filteredClothingItems);
            }
            catch (Exception ex)
            {
                return (ExecutionStatus.INTERNAL_SERVER_ERROR, null);
            }
        }
*******/
    }
}
