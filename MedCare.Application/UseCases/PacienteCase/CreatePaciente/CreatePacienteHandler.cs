using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.PacienteCase.CreatePaciente;

public class CreatePacienteHandler : IRequestHandler<CreatePacienteRequest, Response>
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public CreatePacienteHandler(IUnitOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }
    public async Task<Response> Handle(CreatePacienteRequest request, CancellationToken cancellationToken)
    {
        try 
        {
            Paciente? pacienteCpfJaCadastrado = await _uof.PacienteRepository.GetEntityFilter(p => p.cpf == request.cpf.Replace(".", "").Replace("-", "").Replace("/", ""));

            if (pacienteCpfJaCadastrado is null)
                return new Response(CodeStateResponse.Warning).AddAvisoMensagem("CPF já cadastrado");

            Paciente? pacienteCelularJaCadastrado = await _uof.PacienteRepository.GetEntityFilter(p => p.celular == request.celular);

            if (pacienteCelularJaCadastrado is null)
                return new Response(CodeStateResponse.Warning).AddAvisoMensagem("Celular já cadastrado");

            Paciente paciente = new(request.nome, request.cpf, request.sexo, request.datanascimento, request.endereco, request.celular, request.email);

            _uof.PacienteRepository.Add(paciente);

            await _uof.Commit(cancellationToken);
            return new Response(_mapper.Map<CreatePacienteResponse>(paciente)).AddSucessoMensagem("Registro cadastrado com sucesso");
        }
        catch (Exception ex) 
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
