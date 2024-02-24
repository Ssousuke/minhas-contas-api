using MinhasContas.API.Models.EnumAux;
using System.ComponentModel.DataAnnotations;

namespace MinhasContas.API.Models;

public class Transacao
{
    [Key]
    public Guid Guid { get; private set; }
    public decimal Valor { get; private set; }
    public TipoTransacao TipoTransacao { get; private set; }
    public string? NomeTransacao { get; private set; }
    public DateTime DataTransacao { get; private set; }

    public Conta Conta { get; private set; }
    public Guid ContaGuid { get; private set; }
}