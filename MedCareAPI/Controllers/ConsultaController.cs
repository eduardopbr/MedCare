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
        return Ok(response.Result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Response>> Get(int id)
    {
        var response = await _mediator.Send(new GetConsultaRequest(id));

        return Ok(response.Result);
    }

    [HttpPost]
    public async Task<ActionResult<Response>> Cadastrar([FromBody] CreateConsultaRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response.Result);
    }

    [HttpPut]
    public async Task<ActionResult<Response>> Editar([FromBody] UpdateConsultaRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response.Result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Response>> Deletar(int id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteConsultaRequest(id), cancellationToken);
        return Ok(response.Result);
    }
}
