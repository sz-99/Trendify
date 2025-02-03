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
            List<int> chosenIds = new List<int>();
            for(int i = 0; i < 3; i ++)
            {
                var newId = GetUniqueId(clothingIdList, chosenIds);
                chosenIds.Add(newId);
            }

            newOutfit.ClothingItemsIds = chosenIds;

            return(ExecutionStatus.SUCCESS, newOutfit);

        }

        public int GetUniqueId(List<int> clothingIdList, List<int> chosenIds)
        {
            List<int> candidateIds = clothingIdList.Where(id=>!chosenIds.Contains(id)).ToList();
            int idx = new Random().Next(0, candidateIds.Count);
            return candidateIds[idx];
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
