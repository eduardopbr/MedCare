using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.ExameCase.GetExame
{
    public sealed record GetExameRequest(int id) : IRequest<Response>;
}
