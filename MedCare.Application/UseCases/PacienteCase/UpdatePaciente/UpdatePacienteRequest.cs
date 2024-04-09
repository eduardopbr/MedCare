using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.PacienteCase.UpdatePaciente
{
    public sealed record UpdatePacienteRequest(int id, string nome) : IRequest<Response>;
}
