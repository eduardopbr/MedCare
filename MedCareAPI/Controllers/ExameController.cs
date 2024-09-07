
using MedCare.Application.Shared.Behavior;
using MedCare.Application.UseCases.ExameCase.CreateExame;
using MedCare.Application.UseCases.ExameCase.DeleteExame;
using MedCare.Application.UseCases.ExameCase.GetAllExames;
using MedCare.Application.UseCases.ExameCase.GetExame;
using MedCare.Application.UseCases.ExameCase.UpdateExame;
using MedCare.Application.UseCases.ProcedimentoCase.CreateProcedimento;
using MedCare.Application.UseCases.ProcedimentoCase.DeleteProcedimento;
using MedCare.Application.UseCases.ProcedimentoCase.GetAllProcedimentos;
using MedCare.Application.UseCases.ProcedimentoCase.GetProcedimento;
using MedCare.Application.UseCases.ProcedimentoCase.UpdateProcedimento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController : BaseApiController
    {
        [HttpGet("todos")]
        public async Task<ActionResult<Response>> GetAll()
        {
            var response = await _mediator.Send(new GetAllExamesRequest());

            return Ok(response.Result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> Get(int id)
        {
            var response = await _mediator.Send(new GetExameRequest(id));

            return Ok(response.Result);
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Cadastrar([FromBody] CreateExameRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response.Result);
        }

        [HttpPut]
        public async Task<ActionResult<Response>> Editar([FromBody] UpdateExameRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response.Result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> Deletar(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteExameRequest(id), cancellationToken);
            return Ok(response.Result);
        }
    }
}
