using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.FuncionarioCase.UpdateFuncionario
{
    public sealed record UpdateFuncionarioRequest(int id, string nome, string cpf, string sexo, DateTime datanascimento, string endereco, string celular, string email, string cargo,
                                                  string? registr_profissional, string? especialidade) : IRequest<Response>;
}
