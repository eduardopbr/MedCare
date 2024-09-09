using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.PacienteCase.UpdatePaciente;

public class UpdatePacienteHandler : IRequestHandler<UpdatePacienteRequest, Response>
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public UpdatePacienteHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _uof = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(UpdatePacienteRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var paciente = await _uof.PacienteRepository.GetById(request.id, cancellationToken);

            if (paciente is null) return new Response(CodeStateResponse.Warning).AddError("Paciente não localizado");

            Paciente? pacienteCpfJaCadastrado = await _uof.PacienteRepository.GetEntityFilter(p => p.cpf == request.cpf && p.id != request.id);

            if (pacienteCpfJaCadastrado is null)
                return new Response(CodeStateResponse.Warning).AddAvisoMensagem("CPF já cadastrado");

            paciente.Atualizar(request.nome, request.cpf, request.sexo, request.datanascimento, request.endereco, request.celular, request.email);

            _uof.PacienteRepository.Update(paciente);

            await _uof.Commit(cancellationToken);

            return new Response(_mapper.Map<UpdatePacienteResponse>(paciente));
        }
        catch(Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
