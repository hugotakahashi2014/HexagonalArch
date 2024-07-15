using Newtonsoft.Json;

namespace MeiosPagamentoApi.Models
{
    public class RespostaConsultaPagamentoFiserv
    {
        public string code { get; set; }
        public string message { get; set; }

        [JsonProperty("payment")]
        public RespostaConsultaPagamentoDetalhesFiserv? payment { get; set; }
    }
}
