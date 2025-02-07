using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class WeatherInfo
    {
        public int Id { get; set; }
        [JsonPropertyName("location")]

        public string Location { get; set; }
        [JsonPropertyName("avgTemp")]

        public float AvgTemp { get; set; }
        [JsonPropertyName("minTemp")]

        public float MinTemp {  get; set; }
        [JsonPropertyName("maxTemp")]

        public float MaxTemp { get; set; }
        [JsonPropertyName("Precipitation")]

        public float Precipitation { get; set; }
        [JsonPropertyName("condition")]

        public string Condition { get; set; }
        [JsonPropertyName("conditionIconUrl")]
        public string ConditionIconUrl { get; set; }   
    }
}
