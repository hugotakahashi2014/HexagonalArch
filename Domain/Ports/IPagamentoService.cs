using FiservApi.Models;
using MeiosPagamentoApi.Models;

namespace MeiosPagamentoApi.Interface
{
    public interface IPagamentoService
    {
        Task<RespostaLinkFiserv> GerarLinkPagamento(DadosPagamentoFiserv dadosPagamento);
        Task<RespostaConsultaPagamentoFiserv> ConsultarPagamento(string nit);

    }
}
