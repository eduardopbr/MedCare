using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.ConsultaCase.GetConsulta
{
    public sealed record GetConsultaRequest(int id) : IRequest<Response>;
}
