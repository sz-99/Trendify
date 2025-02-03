namespace Backend.Models
{
    public class WeatherInfo
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public float MinTemp {  get; set; }
        public float MaxTemp { get; set; }
        public float Precipication { get; set; }
    }
}
