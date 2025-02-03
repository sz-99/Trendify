namespace Backend.Models
{
    public class PaginatedResponse
    {
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public int TotalItems { get; set; }
            public int TotalPages { get; set; }
            public List<ClothingItem> clothingItems { get; set; } = new();        
    }
}
