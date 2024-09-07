using MedCare.Application.Shared.Behavior;
using MedCare.Application.UseCases.PacienteCase.CreatePaciente;
using MedCare.Application.UseCases.PacienteCase.DeletePaciente;
using MedCare.Application.UseCases.PacienteCase.GetAllPacientes;
using MedCare.Application.UseCases.PacienteCase.GetPaciente;
using MedCare.Application.UseCases.PacienteCase.UpdatePaciente;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : BaseApiController
    {
        [HttpGet("todos")]
        public async Task<ActionResult<Response>> GetAllPacientes()
        {
            var response = await _mediator.Send(new GetAllPacientesRequest());

            return Ok(response.Result);
        }
        [HttpGet("{pacienteid}")]
        public async Task<ActionResult<Response>> Get(int pacienteid)
        {
            var response = await _mediator.Send(new GetPacienteRequest(pacienteid));

            return Ok(response.Result);
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Cadastrar([FromBody] CreatePacienteRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response.Result);
        }

        [HttpPut]
        public async Task<ActionResult<Response>> Editar([FromBody] UpdatePacienteRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response.Result);
        }

        [HttpDelete("{pacienteid}")]
        public async Task<ActionResult<Response>> Deletar(int pacienteid, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeletePacienteRequest(pacienteid), cancellationToken);

            return Ok(response.Result);
        }
    }
}
