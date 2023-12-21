using System.Text.Json.Serialization;

namespace APIDeps.Models
{
    public class PessoaJuridicaModel
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("cpfFormatado")]
        public string? CpfFormatado { get; set; }

        [JsonPropertyName("cnpjFormatado")]
        public string? CnpjFormatado { get; set; }

        [JsonPropertyName("numeroInscricaoSocial")]
        public string? NumeroInscricaoSocial { get; set; }

        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("razaoSocialReceita")]
        public string? RazaoSocialReceita { get; set; }

        [JsonPropertyName("nomeFantasiaReceita")]
        public string? NomeFantasiaReceita { get; set; }

        [JsonPropertyName("tipo")]
        public string? Tipo { get; set; }
    }
}
