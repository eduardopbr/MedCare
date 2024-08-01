using MedCare.Application.Shared.Behavior;
using MediatR;

namespace MedCare.Application.UseCases.PacienteCase.GetAllPacientes;

public sealed record GetAllPacientesRequest() : IRequest<Response>;