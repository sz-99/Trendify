namespace Backend.Models
{
    public class WearingEvent
    {
        public int OutfitID { get; set; }

        public int UserID { get; set; }

        public DateOnly Date {  get; set; }
    }
}
