using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.FuncionarioCase.DeleteFuncionario
{
    public sealed record DeleteFuncionarioRequest(int id) : IRequest<Response>;
}
