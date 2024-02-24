using MinhasContas.API.Context;
using MinhasContas.API.Models;
using MinhasContas.API.Models.EnumAux;

namespace MinhasContas.API.IRepositorios.Repositorio
{
    public class TransacaoRepositorio(AppDbContext _context) : ITransacaoRepositorio
    {
        public async Task<bool> Transacao(Transacao transacao)
        {
            try
            {
                var conta = _context.Contas.Where(p => p.Guid == transacao.ContaGuid);
                if (transacao.TipoTransacao == TipoTransacao.DEPOSITO)
                    conta.Select(x => x.Deposito(transacao.Valor));

                else if (transacao.TipoTransacao == TipoTransacao.SAQUE)
                    conta.Select(x => x.Saque(transacao.Valor));

                await _context.Transacoes.AddAsync(transacao);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
