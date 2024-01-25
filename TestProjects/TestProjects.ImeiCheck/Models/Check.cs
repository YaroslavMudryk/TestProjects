using System.Text.Json.Serialization;
using TestProjects.ImeiCheck.Converters;

namespace TestProjects.ImeiCheck.Models
{
    public class Check<TDevice> where TDevice : BaseDetails
    {
        [JsonPropertyName("amount")]
        public string Amount { get; set; }
        [JsonPropertyName("deviceId")]
        public string DeviceId { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; }
        [JsonPropertyName("processedAt")]
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTime ProcessedAt { get; set; }
        [JsonPropertyName("properties")]
        public TDevice Details { get; set; }
        [JsonPropertyName("service")]
        public Service Service { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}