using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.FuncionarioCase.CreateFuncionario
{
    public sealed record CreateFuncionarioRequest(string nome, string cpf, string sexo, DateTime datanascimento, string endereco, string celular, string email, string cargo,
                                                  string? registr_profissional, string? especialidade) : IRequest<Response>;
}
