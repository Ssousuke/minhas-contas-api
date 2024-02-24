using MinhasContas.API.Models;

namespace MinhasContas.API.IRepositorios
{
    public interface IContaRespositorio
    {
        Task<bool> CriarConta(Conta conta);
        Task<Conta> BuscarTransacoes(Guid idConta);
    }
}
