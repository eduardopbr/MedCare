using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.FuncionarioCase.GetFuncionario;

public class GetFuncionarioHandler : IRequestHandler<GetFuncionarioRequest, Response>
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public GetFuncionarioHandler(IUnitOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetFuncionarioRequest request, CancellationToken cancellationToken)
    {
        try
        {
            Funcionario? funcionario = await _uof.FuncionarioRepository.GetById(request.funcionarioid, cancellationToken);

            if (funcionario is null)
                return new Response(CodeStateResponse.Warning).AddError("Funcionário não encontrado");

            FuncionarioResponse response = FuncionarioResponse.CreateResponse(funcionario);

            return new Response(response);
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
