using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.ConsultaCase.CreateConsulta
{
    public sealed record CreateConsultaRequest(int pacienteid, int funcionarioid, DateTime datanascimento, int registro, string especialidade, string diagnostico, string? examesrelacionados) : IRequest<Response>;
}
