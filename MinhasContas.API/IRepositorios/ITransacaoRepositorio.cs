using MinhasContas.API.Models;

namespace MinhasContas.API.IRepositorios
{
    public interface ITransacaoRepositorio
    {
        Task<bool> Transacao(Transacao transacao);
    }
}
