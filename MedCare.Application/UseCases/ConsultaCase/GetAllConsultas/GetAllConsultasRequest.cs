using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.ConsultaCase.GetAllConsultas;

public sealed record GetAllConsultasRequest() : IRequest<Response>;