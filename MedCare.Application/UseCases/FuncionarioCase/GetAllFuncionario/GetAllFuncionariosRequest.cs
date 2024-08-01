using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.FuncionarioCase.GetAllFuncionario;

public sealed record GetAllFuncionariosRequest() : IRequest<Response>;