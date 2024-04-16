using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.ProcedimentoCase.GetProcedimento
{
    public sealed record GetProcedimentoRequest(int id) : IRequest<Response>;
}
