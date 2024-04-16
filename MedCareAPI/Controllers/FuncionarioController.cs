using MedCare.Application.Shared.Behavior;
using MedCare.Application.UseCases.FuncionarioCase.CreateFuncionario;
using MedCare.Application.UseCases.FuncionarioCase.DeleteFuncionario;
using MedCare.Application.UseCases.FuncionarioCase.GetFuncionario;
using MedCare.Application.UseCases.FuncionarioCase.UpdateFuncionario;
using Microsoft.AspNetCore.Mvc;

namespace MedCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : BaseApiController
    {
        [HttpGet("{funcionarioid}")]
        public async Task<ActionResult<Response>> Get(int funcionarioid)
        {
            var response = await _mediator.Send(new GetFuncionarioRequest(funcionarioid));

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Cadastrar([FromBody] CreateFuncionarioRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }

        [HttpPut("")]
        public async Task<ActionResult<Response>> Editar([FromBody] UpdateFuncionarioRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }

        [HttpDelete("{funcionarioid}")]
        public async Task<ActionResult<Response>> Deletar(int funcionarioid, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteFuncionarioRequest(funcionarioid), cancellationToken);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }
    }
}
