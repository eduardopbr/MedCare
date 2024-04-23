using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.ConsultaCase.UpdateConsulta
{
    public sealed record UpdateConsultaRequest(int id, int pacienteid, int funcionarioid, DateTime datanascimento, int registro, string especialidade, string diagnostico, string? examesrelacionados) : IRequest<Response>;
}
