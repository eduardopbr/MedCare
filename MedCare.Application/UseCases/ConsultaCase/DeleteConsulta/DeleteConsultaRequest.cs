using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.ConsultaCase.DeleteConsulta
{
    public sealed record DeleteConsultaRequest(int id) : IRequest<Response>;
}
