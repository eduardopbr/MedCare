using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.PacienteCase.GetPaciente;

public class GetPacienteHandler : IRequestHandler<GetPacienteRequest, Response>
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public GetPacienteHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _uof = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetPacienteRequest request, CancellationToken cancellationToken)
    {
        try
        {
            Paciente? paciente = await _uof.PacienteRepository.GetById(request.pacienteid, cancellationToken);

            if (paciente is null)
                return new Response(CodeStateResponse.Warning).AddError("Paciente não encontrado");

            PacienteResponse response = PacienteResponse.CreateResponse(paciente);

            return new Response(response);
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
