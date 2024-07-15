using FiservApi.Models;
using MeiosPagamentoApi.Models;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using MeiosPagamentoApi.Services;


namespace FiservApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FiservController : ControllerBase
{
       
    private static ConfigurationFiserv _config;
    public FiservController(IOptions<ConfigurationFiserv> options)
    {
        _config = options.Value;
    }

    [HttpPost("gerarLink")]
    public async Task<IActionResult> GerarLink([FromBody] DadosPagamentoFiserv dadosPagamento)
    {
        try
        {
            RespostaLinkFiserv respLink;
            //enviar requisição post para a api da Fiserv
            // RunAsync().GetAwaiter().GetResult();
            FiservService fiservService = new FiservService(_config);

            if ((respLink = await fiservService.GerarLinkPagamento(dadosPagamento)) is not null) 
            {
                return Ok(respLink);
            }
            return BadRequest("Não foi possível gerar o link");

        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error\n"+ ex.Message);
        }


    }

    [HttpGet("{nit}")]
    public async Task<IActionResult> ConsultarPagamento(string nit)
    {
        try
        {
            RespostaConsultaPagamentoFiserv consultaPagamento;
            FiservService fiservService = new FiservService(_config);
            if ((consultaPagamento = await fiservService.ConsultarPagamento(nit)) is not null)
            {
                return Ok(consultaPagamento);
            }
            return BadRequest("Não foi possível consultar pagamento");
        }

        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error\n"+ ex.Message);
        }

    }
            

}
