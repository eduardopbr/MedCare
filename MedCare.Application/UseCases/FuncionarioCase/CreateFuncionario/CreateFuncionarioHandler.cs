using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.FuncionarioCase.CreateFuncionario;

public class CreateFuncionarioHandler : IRequestHandler<CreateFuncionarioRequest, Response>
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public CreateFuncionarioHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _uof = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Response> Handle(CreateFuncionarioRequest request, CancellationToken cancellationToken)
    {
        try
        {
            Funcionario? funcionarioCpfJaCadastrado = await _uof.FuncionarioRepository.GetEntityFilter(p => p.cpf == request.cpf);

            if (funcionarioCpfJaCadastrado is null)
                return new Response(CodeStateResponse.Warning).AddAvisoMensagem("CPF já cadastrado");

            Funcionario funcionario = new(request.nome, request.cpf, request.sexo, request.datanascimento, request.cargo, request.registr_profissional, request.especialidade, request.endereco, request.celular, request.email);

            _uof.FuncionarioRepository.Add(funcionario);

            await _uof.Commit(cancellationToken);
            return new Response(_mapper.Map<FuncionarioBaseResponse>(funcionario)).AddSucessoMensagem("Funcionário cadastrado com sucesso");
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
