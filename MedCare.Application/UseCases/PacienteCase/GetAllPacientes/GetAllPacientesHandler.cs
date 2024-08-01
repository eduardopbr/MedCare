using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Application.UseCases.PacienteCase.GetPaciente;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.PacienteCase.GetAllPacientes;

public class GetAllPacientesHandler : IRequestHandler<GetAllPacientesRequest, Response>
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public GetAllPacientesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _uof = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetAllPacientesRequest request, CancellationToken cancellationToken)
    {
        try
        {
            List<Paciente> pacientes = await _uof.PacienteRepository.GetAll(cancellationToken);

            return new Response(_mapper.Map<List<PacienteBaseResponse>>(pacientes));
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
