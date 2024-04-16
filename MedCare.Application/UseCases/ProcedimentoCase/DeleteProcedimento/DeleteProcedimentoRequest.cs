using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.ProcedimentoCase.DeleteProcedimento
{
    public sealed record DeleteProcedimentoRequest(int id) : IRequest<Response>;
}
