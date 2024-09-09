using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ProcedimentoCase.UpdateProcedimento;

public class UpdateProcedimentoHandler : IRequestHandler<UpdateProcedimentoRequest, Response>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProcedimentoHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(UpdateProcedimentoRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var procedimento = await _unitOfWork.ProcedimentoRepository.GetById(request.procedimentoid, cancellationToken);

            if (procedimento is null) return new Response(CodeStateResponse.Warning).AddError("Procedimento não localizado");

            procedimento.Atualizar(request.tipo, request.funcionarioid, request.pacienteid, request.data, request.hora);

            _unitOfWork.ProcedimentoRepository.Update(procedimento);

            await _unitOfWork.Commit(cancellationToken);

            return new Response(_mapper.Map<ProcedimentoBaseResponse>(procedimento)).AddSucessoMensagem("Procedimento atualizado com sucesso");
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
