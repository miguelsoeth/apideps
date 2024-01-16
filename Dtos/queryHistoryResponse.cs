namespace postgreAPI.Dtos
{
    public class queryHistoryResponse
    {
        public string username { get; set; }
        public string type { get; set; }
        public string document { get; set; }
        public DateTime referredDate { get; set; }
        public string interval { get; set; }
        public string? interval_label {  get; set; }
    }
}
