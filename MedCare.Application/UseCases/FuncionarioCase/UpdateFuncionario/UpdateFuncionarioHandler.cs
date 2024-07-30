using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.FuncionarioCase.UpdateFuncionario;

public class UpdateFuncionarioHandler : IRequestHandler<UpdateFuncionarioRequest, Response>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateFuncionarioHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(UpdateFuncionarioRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var funcionario = await _unitOfWork.FuncionarioRepository.GetById(request.id, cancellationToken);

            if (funcionario is null)
                return new Response(CodeStateResponse.Warning).AddError("Funcionário não localizado");

            funcionario.Atualizar(
                request.nome, 
                request.cpf, 
                request.sexo, 
                request.datanascimento, 
                request.cargo, 
                request.registr_profissional, 
                request.especialidade, 
                request.endereco, 
                request.celular, 
                request.email
            );

            _unitOfWork.FuncionarioRepository.Update(funcionario);

            await _unitOfWork.Commit(cancellationToken);

            return new Response(_mapper.Map<FuncionarioBaseResponse>(funcionario));
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
