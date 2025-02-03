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
        public (ExecutionStatus status, ClothingItem clothingItem) ReplaceClothingItem(int id, ClothingItem clothingItem) 
        {
            try
            {
                var clothingItemToUpdate = _repository.FindClothingItemById(id);

                if (clothingItemToUpdate == null)
                    return (ExecutionStatus.NOT_FOUND, null);

                clothingItemToUpdate.UserId = id;
                clothingItemToUpdate.ImageId = clothingItem.ImageId;
                clothingItemToUpdate.Name = clothingItem.Name;
                clothingItemToUpdate.Category = clothingItem.Category;
                clothingItemToUpdate.Size= clothingItem.Size;
                clothingItemToUpdate.Brand = clothingItem.Brand;
                clothingItemToUpdate.Colour = clothingItem.Colour;
                clothingItemToUpdate.Occasion = clothingItem.Occasion;
                clothingItemToUpdate.Season = clothingItem.Season;

                var updatedClothingItem = _repository.ReplaceClothingItem(clothingItemToUpdate);

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
                var filteredClothingItems = _repository.FindAllClothingItems();
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

        public (ExecutionStatus status, ClothingItem ClothingItem) FindClothingItemById(int id)
        {
                try
                {
                    var filteredClothingItems = _repository.FindClothingItemById(id);
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
    }
}
