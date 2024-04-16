using FluentValidation;

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
