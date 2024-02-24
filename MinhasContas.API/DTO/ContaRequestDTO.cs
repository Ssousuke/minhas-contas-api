using MinhasContas.API.Models;
using System.Text.Json.Serialization;

namespace MinhasContas.API.DTO
{
    public class ContaRequestDTO
    {
        [JsonPropertyName("nome-usuario")]
        public string? Usuario { get; set; }
        [JsonPropertyName("saldo-inicial")]
        public decimal Saldo { get; set; }

    }
}
