using System.Text.Json.Serialization;

namespace TestProjects.ImeiCheck.Models
{
    public class XiaomiDetails : BaseDetails
    {
        [JsonPropertyName("activationDate")]
        public int ActivationDate { get; set; }
        [JsonPropertyName("deliveryDate")]
        public int DeliveryDate { get; set; }
        [JsonPropertyName("deviceName")]
        public string DeviceName { get; set; }
        [JsonPropertyName("miActivationLock")]
        public string MiActivationLock { get; set; }
        [JsonPropertyName("modelCode")]
        public string ModelCode { get; set; }
        [JsonPropertyName("productionDate")]
        public int ProductionDate { get; set; }
        [JsonPropertyName("purchaseCountry")]
        public string PurchaseCountry { get; set; }
        [JsonPropertyName("skuNumber")]
        public string SkuNumber { get; set; }
        [JsonPropertyName("unlockNumber")]
        public string UnlockNumber { get; set; }
    }
}