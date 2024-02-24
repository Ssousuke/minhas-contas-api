using Microsoft.AspNetCore.Mvc;
using MinhasContas.API.Adapter.AdapterTransacao;
using MinhasContas.API.DTO;
using MinhasContas.API.IRepositorios;

namespace MinhasContas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly TransacaoAdapterRequest _transacaoAdapterRequest;
        private readonly ITransacaoRepositorio _transacaoRepositorio;

        public TransacaoController(ITransacaoRepositorio transacaoRepositorio)
        {
            _transacaoAdapterRequest = new TransacaoAdapterRequest();
            _transacaoRepositorio = transacaoRepositorio;
        }

        [HttpPost("criar-transacao")]
        public async Task<IActionResult> CriarTransacao(TransacaoRequestDTO transacaoRequest)
        {
            var transacao = _transacaoAdapterRequest.Map(transacaoRequest);
            var newTransacao = await _transacaoRepositorio.Transacao(transacao);
            return newTransacao is true
                ? Ok("Transação realizada com sucesso!")
                : BadRequest("Ocorreu um erro durante o processamento.");
        }
    }
}
