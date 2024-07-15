using Newtonsoft.Json;

namespace MeiosPagamentoApi.Models
{
    public class DadosPagamentoFiservDadosAdicionais
    {

        [JsonProperty("payer")]
        public DadosPagamentoFiservPagador? payer { get; set; }
    }
}
