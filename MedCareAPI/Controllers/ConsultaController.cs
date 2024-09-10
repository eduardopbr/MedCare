using MedCare.Application.Shared.Behavior;
using MedCare.Application.UseCases.ConsultaCase.CreateConsulta;
using MedCare.Application.UseCases.ConsultaCase.DeleteConsulta;
using MedCare.Application.UseCases.ConsultaCase.GetAllConsultas;
using MedCare.Application.UseCases.ConsultaCase.GetConsulta;
using MedCare.Application.UseCases.ConsultaCase.UpdateConsulta;
using MedCare.Application.UseCases.ProcedimentoCase.GetAllProcedimentos;
using Microsoft.AspNetCore.Mvc;

namespace MedCare.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsultaController : BaseApiController
{
    [HttpGet("todos")]
    public async Task<ActionResult<Response>> GetAll()
    {
        var response = await _mediator.Send(new GetAllConsultasRequest());
        return Ok(response);
    }

    [HttpGet("{consulta_id}")]
    public async Task<ActionResult<Response>> Get(int consulta_id)
    {
        var response = await _mediator.Send(new GetConsultaRequest(consulta_id));

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response>> Cadastrar([FromBody] CreateConsultaRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response>> Editar([FromBody] UpdateConsultaRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{consulta_id}")]
    public async Task<ActionResult<Response>> Deletar(int consulta_id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteConsultaRequest(consulta_id), cancellationToken);
        return Ok(response);
    }
}
