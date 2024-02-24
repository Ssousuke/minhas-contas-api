using MinhasContas.API.Models.EnumAux;
using System.Text.Json.Serialization;

namespace MinhasContas.API.DTO
{
    public class TransacaoRequestDTO
    {
        [JsonPropertyName("valor")]
        public decimal Valor { get; set; }
        [JsonPropertyName("tipo-transacao")]
        public TipoTransacao TipoTransacao { get; set; }
        [JsonPropertyName("nome-transacao")]
        public string? NomeTransacao { get; set; }
        [JsonPropertyName("data-transacao")]
        public DateTime DataTransacao { get; set; }
        [JsonPropertyName("id-conta")]
        public Guid ContaGuid { get; set; }
    }
}
