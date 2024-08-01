using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.ExameCase.GetAllExames;

public sealed record GetAllExamesRequest() : IRequest<Response>;