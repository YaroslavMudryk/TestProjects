using System.Text.Json.Serialization;

namespace TestProjects.ImeiCheck.Models
{
    public class BaseDetails
    {
        [JsonPropertyName("serial")]
        public string SerialNumber { get; set; }
        [JsonPropertyName("imei")]
        public string Imei { get; set; }
        [JsonPropertyName("imei2")]
        public string Imei2 { get; set; }
        [JsonPropertyName("warrantyStatus")]
        public string WarrantyStatus { get; set; }
    }
}