using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.PacienteCase.UpdatePaciente
{
    public sealed record UpdatePacienteRequest(int id, string nome, string cpf, string sexo, DateTime datanascimento, string endereco, string celular, string email) : IRequest<Response>;
}
