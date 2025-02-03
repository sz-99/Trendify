using Backend.Models;
using Backend.Models.Enums;
using System.Reflection.Metadata.Ecma335;

namespace Backend.Services
{
    public class OutfitService: IOutfitService
    {
        private IClothingItemsRepository _repository;
        public OutfitService(IClothingItemsRepository repository)
        {
            _repository = repository;
        }

        public (ExecutionStatus, Outfit) MakeOutfit()
        {
            Outfit newOutfit = new Outfit();
            var clothingIdList = _repository.FindAllClothingItems().Select(c=>c.Id).ToList();
            List<int> clothingListIndex = new List<int>()
            {
                new Random().Next(0, clothingIdList.Count),
                new Random().Next(0, clothingIdList.Count),
                new Random().Next(0, clothingIdList.Count)
            };

            newOutfit.ClothingItemsIds = new List<int>()
            {
               clothingIdList[clothingListIndex[0]],
               clothingIdList[clothingListIndex[1]],
               clothingIdList[clothingListIndex[2]]
            };

            return(ExecutionStatus.SUCCESS, newOutfit);

        }

        public (ExecutionStatus, List<ClothingItem>) MakeOutfitToList()
        {
            var (status, outfit) = MakeOutfit();
            if(status == ExecutionStatus.SUCCESS)
            {
                return(ExecutionStatus.SUCCESS, outfit.ClothingItemsIds.Select(id=>_repository.FindClothingItemById(id)).ToList());
            }
            else
            {
                return (status, null);
            }

        }
    }
}
