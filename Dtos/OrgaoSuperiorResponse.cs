namespace APIDeps.Dtos
{
    public class OrgaoSuperiorResponse
    {
        public string? Nome { get; set; }
        public string? CodigoSIAFI { get; set; }
        public string? Cnpj { get; set; }
        public string? Sigla { get; set; }
        public string? DescricaoPoder { get; set; }
        public OrgaoMaximoResponse? OrgaoMaximo { get; set; }
    }
}
