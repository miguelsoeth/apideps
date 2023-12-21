using System.Text.Json.Serialization;

namespace APIDeps.Models
{
    public class OrgaoSuperiorModel
    {
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("codigoSIAFI")]
        public string? CodigoSIAFI { get; set; }

        [JsonPropertyName("cnpj")]
        public string? Cnpj { get; set; }

        [JsonPropertyName("sigla")]
        public string? Sigla { get; set; }

        [JsonPropertyName("descricaoPoder")]
        public string? DescricaoPoder { get; set; }

        [JsonPropertyName("orgaoMaximo")]
        public OrgaoMaximoModel? OrgaoMaximo { get; set; }
    }
}
