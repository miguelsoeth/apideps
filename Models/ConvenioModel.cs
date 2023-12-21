using System.Text.Json.Serialization;

namespace APIDeps.Models
{
    public class ConvenioModel
    {
        [JsonPropertyName("codigo")]
        public string? Codigo { get; set; }

        [JsonPropertyName("objeto")]
        public string? Objeto { get; set; }

        [JsonPropertyName("numero")]
        public string? Numero { get; set; }
    }
}
