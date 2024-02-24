using MinhasContas.API.Models;
using System.Text.Json.Serialization;

namespace MinhasContas.API.DTO
{
    public class ContaResponseDTO
    {
        [JsonPropertyName("id-conta")]
        public Guid Guid { get; set; }

        [JsonPropertyName("nome-usuario")]
        public string? Usuario { get; set; }
        [JsonPropertyName("saldo-inicial")]
        public decimal Saldo { get; set; }

        [JsonPropertyName("lista-transacao")]
        public IEnumerable<TransacaoResponseDTO>? Transacao { get; set; }
    }
}
