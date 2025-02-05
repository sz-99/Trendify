using Backend.Models;
using Backend.Models.Enums;

namespace Backend.Services
{
    public interface IOutfitService
    {
        (ExecutionStatus, Outfit) MakeOutfit();
        Task<(ExecutionStatus, List<ClothingItem>)> MakeOutfitToList(string location);
    }
}