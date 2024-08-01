using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Application.UseCases.FuncionarioCase.GetAllFuncionario;
using MedCare.Application.UseCases.FuncionarioCase;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ExameCase.GetAllExames;

public class GetAllExamesHandler : IRequestHandler<GetAllExamesRequest, Response>
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public GetAllExamesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _uof = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetAllExamesRequest request, CancellationToken cancellationToken)
    {
        try
        {
            List<Exame> exames = await _uof.ExameRepository.GetAll(cancellationToken);

            return new Response(_mapper.Map<List<ExameBaseResponse>>(exames));
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
