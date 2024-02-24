using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MinhasContas.API.Models;

public class Conta
{
    [Key]
    public Guid Guid { get; private set; }
    public string? Usuario { get; private set; }
    public decimal Saldo { get; private set; }
    public IEnumerable<Transacao>? Transacoes { get; private set; }

    public bool Deposito(decimal valor)
    {
        if (valor < 0)
        {
            Saldo += valor;
            return true;
        }

        return false;
    }

    public bool Saque(decimal valor)
    {
        if (valor < 0)
        {
            Saldo -= valor;
            return true;
        }

        return false;
    }
}