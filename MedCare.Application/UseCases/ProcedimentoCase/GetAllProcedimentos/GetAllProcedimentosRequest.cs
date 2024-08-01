using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.ProcedimentoCase.GetAllProcedimentos;

public sealed record GetAllProcedimentosRequest() : IRequest<Response>;