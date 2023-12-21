namespace APIDeps.Dtos
{
    public class CepimCnpjResponse
    {
        public int? Id { get; set; }
        public string? DataReferencia { get; set; }
        public string? Motivo { get; set; }
        public OrgaoSuperiorResponse? OrgaoSuperior { get; set; }
        public PessoaJuridicaResponse? PessoaJuridica { get; set; }
        public ConvenioResponse? Convenio { get; set; }
    }
}
