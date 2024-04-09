using MedCare.Application.Shared.Behavior;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Application.UseCases.PacienteCase.CreatePaciente
{
    public sealed record CreatePacienteRequest(string nome, string cpf, string rg, string sexo, DateTime datanascimento, string endereco, string celular, string email) : IRequest<Response>;
}
