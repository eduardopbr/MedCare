using MedCare.Application.UseCases.PacienteCase.DeletePaciente;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Application.UseCases.PacienteCase.UpdatePaciente
{
    public sealed record UpdatePacienteRequest(int id, string nome) : IRequest<UpdatePacienteResponse>;
}
