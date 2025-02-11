using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Models.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClothingItemsController : ControllerBase
    {
        IClothingItemsService _clothingItemsService;
        public ClothingItemsController(IClothingItemsService clothingItemsService) 
        {
            _clothingItemsService = clothingItemsService;
        }

        [HttpGet("all")]
        public IActionResult GetAllClothingItems()
        {
            var response = _clothingItemsService.FindAllClothingItems();
            List<ClothingItem> clothingItems = response.clothingItems;
            return response.status switch
            {
                ExecutionStatus.SUCCESS => Ok(clothingItems),
                ExecutionStatus.INTERNAL_SERVER_ERROR => StatusCode(500, "Internal Server Error. Try again Later"),
                ExecutionStatus.NOT_FOUND => NotFound("No Clothing Items Found"),
                _ => StatusCode(500, "Internal Server Error. Try again Later")
            };
        }

        [HttpGet("{id}")]
        public IActionResult GetClothingItemById(int id)
        {
            var response = _clothingItemsService.FindClothingItemById(id);
            ClothingItem clothingItem = response.ClothingItem;
            return response.status switch
            {
                ExecutionStatus.SUCCESS => Ok(clothingItem),
                ExecutionStatus.INTERNAL_SERVER_ERROR => StatusCode(500, "Internal Server Error. Try again Later"),
                ExecutionStatus.NOT_FOUND => NotFound("No clothing item found for this id"),
                _ => StatusCode(500, "Internal Server Error. Try again Later")
            };
        }

        [HttpPost]
        public IActionResult AddClothingItem([FromBody] ClothingItem clothingItem)
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
            var response = _clothingItemsService.AddClothingItem(clothingItem);
            ClothingItem newClothingItem = response.newClothingItem;
            return response.status switch
            {
                ExecutionStatus.SUCCESS => Ok(newClothingItem),
                _ => StatusCode(500, "Internal Server Error. Try again Later")
            };
        }
        [HttpPut("{id}")]
        public IActionResult PutClothingItem(int id, ClothingItem clothingItem)
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
                ExecutionStatus.NOT_FOUND => NotFound("Clothing Item does not exist."),
                _ => StatusCode(500, "Internal Server Error. Try again Later")
            };
        }

        [HttpGet]
        public IActionResult GetClothingItems(
                                                [FromQuery] int? category,
                                                [FromQuery] int? size,
                                                [FromQuery] string? brand,
                                                [FromQuery] string? colour,
                                                [FromQuery] int? occasion,
                                                [FromQuery] int? season
                                              )
         {
            var filter = new ClothingItemFilter
            {
                Category = category,
                Size = size,
                Brand = brand,
                Colour = colour,
                Occasion = occasion,
                Season = season
            };

            var response = _clothingItemsService.GetFilteredClothingItems(filter);
            return response.status switch
            {
                ExecutionStatus.SUCCESS => Ok(response.clothingItems),
                ExecutionStatus.INTERNAL_SERVER_ERROR => StatusCode(500, "Internal Server Error. Try again Later"),
                ExecutionStatus.NOT_FOUND => NotFound("Clothing Item does not exist."),
                _ => StatusCode(500, "Internal Server Error. Try again Later")
            };
        }

    }
}
