using Microsoft.AspNetCore.Mvc;
using MinhasContas.API.Adapter.AdapterConta;
using MinhasContas.API.Adapter.AdapterTransacao;
using MinhasContas.API.DTO;
using MinhasContas.API.IRepositorios;

namespace MinhasContas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaRespositorio _contaRepositorio;
        private readonly ContaAdapterRequest _contaAdapterRequest;
        private readonly ContaAdapterResponse _contaAdapterResponse;
        private readonly TransacaoAdpterResponse _transacaoAdapterResponse;

        public ContaController(IContaRespositorio contaRepositorio)
        {
            _contaRepositorio = contaRepositorio;
            _contaAdapterRequest = new ContaAdapterRequest();
            _contaAdapterResponse = new ContaAdapterResponse();
            _transacaoAdapterResponse = new TransacaoAdpterResponse();
        }

        [HttpPost("criar-conta")]
        public async Task<IActionResult> CriarConta(ContaRequestDTO contaRequest)
        {
            var adapterContaRequest = _contaAdapterRequest.Map(contaRequest);
            var criarConta = await _contaRepositorio.CriarConta(adapterContaRequest);
            return criarConta is true
                ? Ok("Conta foi criada com sucesso!")
                : BadRequest("Ocorreu um erro durante o processamento.");
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> VerConta(Guid id)
        {
            var conta = await _contaRepositorio.BuscarTransacoes(id);

            if (conta is not null)
            {
                var contaResponse = new ContaResponseDTO()
                {
                    Guid = conta.Guid,
                    Usuario = conta.Usuario,
                    Saldo = conta.Saldo,

                    Transacao = _transacaoAdapterResponse.Map(conta.Transacoes).OrderByDescending(x => x.DataTransacao)
                };
                return Ok(contaResponse);
            }
            return NotFound();
        }
    }
}
