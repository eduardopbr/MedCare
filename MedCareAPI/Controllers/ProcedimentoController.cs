using MedCare.Application.Shared.Behavior;
using MedCare.Application.UseCases.PacienteCase.CreatePaciente;
using MedCare.Application.UseCases.PacienteCase.DeletePaciente;
using MedCare.Application.UseCases.PacienteCase.GetAllPacientes;
using MedCare.Application.UseCases.PacienteCase.GetPaciente;
using MedCare.Application.UseCases.PacienteCase.UpdatePaciente;
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
    public class ProcedimentoController : BaseApiController
    {
        [HttpGet("todos")]
        public async Task<ActionResult<Response>> GetAll()
        {
            var response = await _mediator.Send(new GetAllProcedimentosRequest());

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> Get(int id)
        {
            var response = await _mediator.Send(new GetProcedimentoRequest(id));

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Cadastrar([FromBody] CreateProcedimentoRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }

        [HttpPut]
        public async Task<ActionResult<Response>> Editar([FromBody] UpdateProcedimentoRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> Deletar(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteProcedimentoRequest(id), cancellationToken);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }
    }
}
