using System.Text.Json.Serialization;

namespace APIDeps.Dtos
{
    public class CepimCnpjResponse
    {
        public int? Id { get; set; }
        public string? DataReferencia { get; set; }
        public string? Motivo { get; set; }
    }
}
