using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class WearingHistory
    {
        [Key]
        public int OutfitID { get; set; }

        public int UserID { get; set; }

        public DateOnly Date {  get; set; }
    }
}
