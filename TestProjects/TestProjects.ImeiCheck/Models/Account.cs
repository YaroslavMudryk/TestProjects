using System.Text.Json.Serialization;

namespace TestProjects.ImeiCheck.Models
{
    public class Account
    {
        [JsonPropertyName("balance")]
        public string Balance { get; set; }
    }
}