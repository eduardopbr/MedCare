using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.ExameCase.DeleteExame
{
    public sealed record DeleteExameRequest(int id) : IRequest<Response>;
}
