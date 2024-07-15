namespace MeiosPagamentoApi.Models
{
    public class RespostaLinkFiserv
    {
        public int responseCode { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string nit { get; set; }
        public string nita { get; set; }
        public string nsuesitef { get; set; }
    }
}
