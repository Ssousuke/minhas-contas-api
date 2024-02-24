
using Microsoft.EntityFrameworkCore;
using MinhasContas.API.Context;
using MinhasContas.API.Models;

namespace MinhasContas.API.IRepositorios.Repositorio
{
    public class ContaRepositorio : IContaRespositorio
    {
        private readonly AppDbContext _context;

        public ContaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Conta> BuscarTransacoes(Guid idConta)
        {
            return await _context.Contas.Include(x => x.Transacoes)
                                        .SingleOrDefaultAsync(x => x.Guid == idConta);
        }

        public async Task<bool> CriarConta(Conta conta)
        {
            try
            {
                var criarConta = await _context.Contas.AddAsync(conta);
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
