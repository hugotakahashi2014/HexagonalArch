using MeiosPagamentoApi.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FiservApi.Models;

public class DadosPagamentoFiserv
{
    [Required(ErrorMessage = "Id do estabelecimento é obrigatório!")]
    [MaxLength(15, ErrorMessage ="O tamanho não pode exceder 15 caracteres")]
    public string merchant_id { get; set; }

    [JsonIgnore]
    [Required(ErrorMessage ="Chave do estabelecimento é obrigatória")]
    [MaxLength(80,ErrorMessage ="O tamanho não pode exceder 80 caracteres")]
    public string merchant_key { get; set; }
    
    [Required]
    [Range(1, 999999999, ErrorMessage ="Valor máximo excedido")]
    public Int32 amount { get; set; }
    public int installments { get; set; }
    public int installment_type { get; set; } = 3;
    public string store_card { get; set; }
     //public bool payment_link { get; set; } = true;

    [JsonProperty("additional_data")]
    public DadosPagamentoFiservDadosAdicionais? additional_data { get; set; }

}
