using FiservApi.Models;
using MeiosPagamentoApi.Interface;
using MeiosPagamentoApi.Models;
using Newtonsoft.Json;

namespace MeiosPagamentoApi.Services;

public class FiservService
{

    private ConfigurationFiserv _config;

    public FiservService(ConfigurationFiserv config)
    {
        _config = config;
    }

    public async Task<RespostaConsultaPagamentoFiserv> ConsultarPagamento(string nit)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_config.url_base);
            client.DefaultRequestHeaders.Add("merchant_id", _config.merchant_id);
            client.DefaultRequestHeaders.Add("merchant_key", _config.merchant_key);

            var response = await client.GetAsync(_config.endpoint_consulta + nit);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var resp = JsonConvert.DeserializeObject<RespostaConsultaPagamentoFiserv>(jsonResponse);
                if (resp != null)  return resp;
            }
            return null;
            
        }
    }
        public async Task<RespostaLinkFiserv> GerarLinkPagamento(DadosPagamentoFiserv dadosPagamento)
    {
        var parameters = new Dictionary<string, string>();
        var requestJson = JsonConvert.SerializeObject(dadosPagamento);
        parameters.Add("request", requestJson);

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(_config.url_base);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("merchant_key", _config.merchant_key);

            var response = await client
                 .PostAsync(_config.endpoint_link, new FormUrlEncodedContent(parameters));

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var resp = JsonConvert.DeserializeObject<RespostaLinkFiserv>(jsonString);
                if (resp != null)
                    return resp;
            }
            return null;
        }
    }
}
