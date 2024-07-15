using Newtonsoft.Json;

namespace MeiosPagamentoApi.Models
{
    public class RespostaConsultaPagamentoDetalhesFiserv
    {
        public string? status { get; set; }
        public string? nit { get; set; }
        public Int32 amount { get; set; }
        public int installments{ get; set; }
        public string? payment_date { get; set; }

    }
}
