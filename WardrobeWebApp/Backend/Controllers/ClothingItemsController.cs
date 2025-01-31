using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using RecordShop.Model;

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
        [HttpPut("{id}")]
        public IActionResult PutAlbum(int id, ClothingItem clothingItem)
        {
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors;
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return BadRequest();
            }

            var response = _clothingItemsService.ReplaceClothingItem(id, clothingItem);
            ClothingItem updatedclothingItem = response.updatedClothingItem;
            return response.status switch
            {
                ExecutionStatus.SUCCESS => Ok(updatedclothingItem),
                ExecutionStatus.INTERNAL_SERVER_ERROR => StatusCode(500, "Internal Server Error. Try again Later"),
                ExecutionStatus.NOT_FOUND => NotFound("Clothing Item does not exist."),
                _ => StatusCode(500, "Internal Server Error. Try again Later")
            };
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClothingItem(int id)
        {
            var response = _clothingItemsService.DeleteClothingItem(id);

            return response switch
            {
                ExecutionStatus.SUCCESS => Ok(),
                ExecutionStatus.INTERNAL_SERVER_ERROR => StatusCode(500, "Internal Server Error. Try again Later"),
                ExecutionStatus.NOT_FOUND => NotFound("Album does not exist."),
                _ => StatusCode(500, "Internal Server Error. Try again Later")
            };
        }
    }
}
