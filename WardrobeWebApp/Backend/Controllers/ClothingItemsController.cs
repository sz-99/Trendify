using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClothingItemsController : Controller
    {
        IClothingItemsService _clothingItemsService;

        public ClothingItemsController(IClothingItemsService clothingItemsService) 
        {
            _clothingItemsService = clothingItemsService;
        }

        [HttpGet]
        public IActionResult GetAllClothingItems()
        {
            return Ok(_clothingItemsService.FindAllClothingItems());
        }

        [HttpGet("{id}")]
        public IActionResult GetClothingItemById(int id)
        {
            return Ok(_clothingItemsService.FindClothingItemById(id));
        }

        [HttpPost]
        public IActionResult AddClothingItem(ClothingItem clothingItem)
        {
            var newItem = _clothingItemsService.AddClothingItem(clothingItem);
            return Ok(newItem);
        }
    }
}
