using Backend.Models;
using Backend.Models.Enums;
using System.Reflection.Metadata.Ecma335;

namespace Backend.Services
{
    public class OutfitService: IOutfitService
    {
        private IClothingItemsRepository _repository;
        private IWeatherService _weatherService;
        public OutfitService(IClothingItemsRepository repository, IWeatherService weatherService)
        {
            _repository = repository;
            _weatherService = weatherService;
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

        public async Task<(ExecutionStatus, Outfit)> MakeOutfitBasedOnWeather(string location)
        {
            var (status, weather) = await _weatherService.GetWeatherForecast(location);
            if(status != ExecutionStatus.SUCCESS || weather == null) 
                return (ExecutionStatus.NOT_FOUND, null);

            var (sts, outfit) = MakeOutfit();
            if (sts != ExecutionStatus.SUCCESS || outfit == null)
                return (sts, null);

            var modifiedSelection = new List<int>(outfit.ClothingItemsIds);

           try
           {
                if (weather.Precipication > 2.5 && weather.MaxTemp < 20 && weather.AvgTemp > 10)
                {
                    modifiedSelection.Add(GetRandomClothingItem(ClothingKind.Overall));
                }
                else if (weather.AvgTemp <= 10)
                {
                    //add jumper AND coat
                    modifiedSelection.Add(GetRandomClothingItem(ClothingKind.Outer));
                    modifiedSelection.Add(GetRandomClothingItem(ClothingKind.Overall));
                }
                else if (weather.MaxTemp < 15 && weather.MaxTemp > 10)
                {
                    //add jumper or coat
                    var rand = new Random().Next(0, 2);
                    if (rand == 0) //jumper
                    {
                        modifiedSelection.Add(GetRandomClothingItem(ClothingKind.Outer));
                    }
                    else //coat
                    {
                        modifiedSelection.Add(GetRandomClothingItem(ClothingKind.Overall));
                    }
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error in Outfit Generation: {ex.Message}");
                return (ExecutionStatus.INTERNAL_SERVER_ERROR, null);
            }

            outfit.ClothingItemsIds = modifiedSelection;
            return (ExecutionStatus.SUCCESS, outfit);
        }

        public int GetUniqueId(List<int> clothingIdList, List<int> chosenIds)
        {
            List<int> candidateIds = clothingIdList.Where(id=>!chosenIds.Contains(id)).ToList();
            if (candidateIds.Count == 0) throw new InvalidOperationException("No valid clothing to choose from");
            int idx = new Random().Next(0, candidateIds.Count);
            return candidateIds[idx];
        }

        public async Task<(ExecutionStatus, List<ClothingItem>)> MakeOutfitToList(string location)
        {
            var (status, outfit) = await MakeOutfitBasedOnWeather(location);
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
