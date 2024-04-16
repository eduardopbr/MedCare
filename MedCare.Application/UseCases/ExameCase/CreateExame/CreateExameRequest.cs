using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.ExameCase.CreateExame
{
    public sealed record CreateExameRequest(string tipo, int pacienteid, DateTime data, TimeSpan hora, string? resultado) : IRequest<Response>;
}
