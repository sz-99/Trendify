namespace Backend.Models
{
    public class WearingHistory
    {
        public int OutfitID { get; set; }

        public int UserID { get; set; }

        public DateOnly Date {  get; set; }
    }
}
