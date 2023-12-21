using System.Text.Json.Serialization;

namespace APIDeps.Models
{
    public class OrgaoMaximoModel
    {
        [JsonPropertyName("codigo")]
        public string? Codigo { get; set; }

        [JsonPropertyName("sigla")]
        public string? Sigla { get; set; }

        [JsonPropertyName("nome")]
        public string? Nome { get; set; }
    }
}
