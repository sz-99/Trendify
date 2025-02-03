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

        public int GetRandomClothingItem(ClothingKind kind)
        {
            var clothingList = _repository.FindAllClothingItems();
            var filteredListOfIds = clothingList
                .Where(c => ClothingKindMapper.GetClothingKind(c.Category) == kind)
                .Select(c => c.Id)
                .ToList();
            var newId = GetUniqueId(filteredListOfIds, new List<int>() { });
            return newId;
        }

        public (ExecutionStatus, Outfit) MakeOutfit()
        {
            Outfit newOutfit = new Outfit();
            //decide top+bottom OR single
            //filter list based on EITHER single 
            //OR random top+ random bottom
            //temperature + jumper and coat
            var clothingList = _repository.FindAllClothingItems();
            var rand = new Random().Next(0, 2);
            List<int> filteredList = new();

            if(rand == 0) //single
            {
                filteredList = new List<int>() { GetRandomClothingItem(ClothingKind.Single) };
                
            }
            else if(rand == 1) //top + bottom
            {
                filteredList = new List<int>() { 
                    GetRandomClothingItem(ClothingKind.Top), 
                    GetRandomClothingItem(ClothingKind.Bottom) 
                };
            }

            newOutfit.ClothingItemsIds = filteredList;

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
