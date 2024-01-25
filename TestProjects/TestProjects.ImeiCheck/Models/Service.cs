using System.Text.Json.Serialization;

namespace TestProjects.ImeiCheck.Models
{
    public class Service
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("price")]
        public string Price { get; set; }
    }
}