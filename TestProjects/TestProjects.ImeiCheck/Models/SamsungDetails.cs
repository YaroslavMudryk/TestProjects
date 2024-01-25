using System.Text.Json.Serialization;
using TestProjects.ImeiCheck.Converters;

namespace TestProjects.ImeiCheck.Models
{
    public class SamsungDetails : BaseDetails
    {
        [JsonPropertyName("carrier")]
        public string Carrier { get; set; }
        [JsonPropertyName("doNumber")]
        public string DoNumber { get; set; }
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; }
        [JsonPropertyName("modelName")]
        public string ModelName { get; set; }
        [JsonPropertyName("modelNumber")]
        public string ModelNumber { get; set; }
        [JsonPropertyName("productionDate")]
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTime ProductionDate { get; set; }
        [JsonPropertyName("shipDate")]
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTime ShipDate { get; set; }
        [JsonPropertyName("shipToCountry")]
        public string ShipToCountry { get; set; }
        [JsonPropertyName("soldByCountry")]
        public string SoldByCountry { get; set; }
        [JsonPropertyName("soldDate")]
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTime SoldDate { get; set; }
        [JsonPropertyName("warrantyUntil")]
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTime WarrantyUntil { get; set; }
    }
}