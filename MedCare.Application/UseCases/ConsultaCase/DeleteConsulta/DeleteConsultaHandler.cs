using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Application.UseCases.ExameCase.DeleteExame;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ConsultaCase.DeleteConsulta;

public class DeleteConsultaHandler : IRequestHandler<DeleteConsultaRequest, Response>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteConsultaHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(DeleteConsultaRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var consulta = await _unitOfWork.ConsultaRepository.GetById(request.id, cancellationToken);

            if (consulta == null) return new Response(CodeStateResponse.Warning).AddError("Consulta não encontrada");

            _unitOfWork.ConsultaRepository.Delete(consulta);
            await _unitOfWork.Commit(cancellationToken);

            return new Response(CodeStateResponse.Success).AddSucessoMensagem("Registro excluído com sucesso");
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
