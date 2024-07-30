using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.PacienteCase.DeletePaciente;

public class DeletePacienteHandler : IRequestHandler<DeletePacienteRequest, Response>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeletePacienteHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(DeletePacienteRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var paciente = await _unitOfWork.PacienteRepository.GetById(request.id, cancellationToken);

            if (paciente == null) return new Response(CodeStateResponse.Warning).AddError("Paciente não encontrado");

            _unitOfWork.PacienteRepository.Delete(paciente);
            await _unitOfWork.Commit(cancellationToken);

            return new Response(CodeStateResponse.Success);
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
