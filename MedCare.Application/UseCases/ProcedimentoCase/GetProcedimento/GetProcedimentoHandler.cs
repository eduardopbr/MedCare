using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ProcedimentoCase.GetProcedimento;

public class GetProcedimentoHandler : IRequestHandler<GetProcedimentoRequest, Response>
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public GetProcedimentoHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _uof = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetProcedimentoRequest request, CancellationToken cancellationToken)
    {
        try
        {
            Procedimento? procedimento = await _uof.ProcedimentoRepository.GetById(request.id, cancellationToken);

            if (procedimento is null)
                return new Response(CodeStateResponse.Warning).AddError("Procedimento não encontrado");

            return new Response(_mapper.Map<ProcedimentoBaseResponse>(procedimento));
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
