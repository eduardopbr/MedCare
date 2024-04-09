using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Application.UseCases.PacienteCase.CreatePaciente
{
    public class CreatePacienteValidator : AbstractValidator<CreatePacienteRequest>
    {
        public CreatePacienteValidator()
        {
            RuleFor(x => x.email).NotEmpty().MaximumLength(50).EmailAddress();
        }
    }
}
