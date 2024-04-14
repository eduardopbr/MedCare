using MedCare.Application.Shared.Behavior;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Application.UseCases.PacienteCase.GetPaciente
{
    public sealed record GetPacienteRequest(int pacienteid) : IRequest<Response>;
}
