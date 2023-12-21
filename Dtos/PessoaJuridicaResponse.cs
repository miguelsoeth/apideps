namespace APIDeps.Dtos
{
    public class PessoaJuridicaResponse
    {
        public int? Id { get; set; }
        public string? CpfFormatado { get; set; }
        public string? CnpjFormatado { get; set; }
        public string? NumeroInscricaoSocial { get; set; }
        public string? Nome { get; set; }
        public string? RazaoSocialReceita { get; set; }
        public string? NomeFantasiaReceita { get; set; }
        public string? Tipo { get; set; }
    }
}
