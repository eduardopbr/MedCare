using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.ProcedimentoCase.UpdateProcedimento
{
    public sealed record UpdateProcedimentoRequest(int procedimentoid, string tipo, int funcionarioid, int pacienteid, DateTime data, TimeSpan hora) : IRequest<Response>;
}
