using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Application.UseCases.PacienteCase.DeletePaciente
{
    public class DeletePacienteValidator : AbstractValidator<DeletePacienteRequest>
    {
        public DeletePacienteValidator()
        {
            RuleFor(x => x.id).NotEmpty();
        }
    }
}
