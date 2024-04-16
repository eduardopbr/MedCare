using MedCare.Application.Shared.Behavior;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Application.UseCases.ExameCase.UpdateExame
{
    public sealed record UpdateExameRequest(int id, string tipo, int pacienteid, DateTime data, TimeSpan hora, string? resultado) : IRequest<Response>;
}
