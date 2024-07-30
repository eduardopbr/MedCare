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
        var funcionario = _mapper.Map<Funcionario>(request);

        try
        {
            _uof.FuncionarioRepository.Add(funcionario);

            await _uof.Commit(cancellationToken);
            return new Response(_mapper.Map<FuncionarioBaseResponse>(funcionario));
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
