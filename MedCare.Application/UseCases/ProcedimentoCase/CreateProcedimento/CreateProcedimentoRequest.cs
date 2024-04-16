using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.ProcedimentoCase.CreateProcedimento
{
    public sealed record CreateProcedimentoRequest(string tipo, int funcionarioid, int pacienteid, DateTime data, TimeSpan hora) : IRequest<Response>;
}
