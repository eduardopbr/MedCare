using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ProcedimentoCase.CreateProcedimento;

public class CreateProcedimentoHandler : IRequestHandler<CreateProcedimentoRequest, Response>
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public CreateProcedimentoHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _uof = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(CreateProcedimentoRequest request, CancellationToken cancellationToken)
    {
        try
        {
            Procedimento procedimento = new(request.tipo, request.funcionarioid, request.pacienteid, request.data, request.hora);
            _uof.ProcedimentoRepository.Add(procedimento);

            await _uof.Commit(cancellationToken);
            return new Response(_mapper.Map<ProcedimentoBaseResponse>(procedimento)).AddSucessoMensagem("Procedimento registrado com sucesso");
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
