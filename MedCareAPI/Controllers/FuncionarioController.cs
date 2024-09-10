using MedCare.Application.Shared.Behavior;
using MedCare.Application.UseCases.FuncionarioCase.CreateFuncionario;
using MedCare.Application.UseCases.FuncionarioCase.DeleteFuncionario;
using MedCare.Application.UseCases.FuncionarioCase.GetAllFuncionario;
using MedCare.Application.UseCases.FuncionarioCase.GetFuncionario;
using MedCare.Application.UseCases.FuncionarioCase.UpdateFuncionario;
using MedCare.Application.UseCases.ProcedimentoCase.GetAllProcedimentos;
using Microsoft.AspNetCore.Mvc;

namespace MedCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : BaseApiController
    {
        [HttpGet("todos")]
        public async Task<ActionResult<Response>> GetAll()
        {
            var response = await _mediator.Send(new GetAllFuncionariosRequest());
            return Ok(response);
        }

        [HttpGet("{funcionario_id}")]
        public async Task<ActionResult<Response>> Get(int funcionario_id)
        {
            var response = await _mediator.Send(new GetFuncionarioRequest(funcionario_id));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Cadastrar([FromBody] CreateFuncionarioRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpPut("")]
        public async Task<ActionResult<Response>> Editar([FromBody] UpdateFuncionarioRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpDelete("{funcionario_id}")]
        public async Task<ActionResult<Response>> Deletar(int funcionario_id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteFuncionarioRequest(funcionario_id), cancellationToken);

            return Ok(response);
        }
    }
}
