using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.PacienteCase.UpdatePaciente;

public class UpdatePacienteHandler : IRequestHandler<UpdatePacienteRequest, Response>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdatePacienteHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(UpdatePacienteRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var paciente = await _unitOfWork.PacienteRepository.GetById(request.id, cancellationToken);

            if (paciente is null) return new Response(CodeStateResponse.Warning).AddError("Paciente não localizado");

            paciente.Atualizar(request.nome, request.cpf, request.sexo, request.datanascimento, request.endereco, request.celular, request.email);

            _unitOfWork.PacienteRepository.Update(paciente);

            await _unitOfWork.Commit(cancellationToken);

            return new Response(_mapper.Map<UpdatePacienteResponse>(paciente));
        }
        catch(Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
