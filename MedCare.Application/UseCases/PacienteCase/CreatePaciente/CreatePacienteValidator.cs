using FluentValidation;
using MedCare.Application.Shared.Validators;

namespace MedCare.Application.UseCases.PacienteCase.CreatePaciente;

public class CreatePacienteValidator : AbstractValidator<CreatePacienteRequest>
{
    public CreatePacienteValidator()
    {
        RuleFor(x => x.email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(x => x.cpf)
           .Cascade(CascadeMode.Stop)
           .Must(cpfcnpj => string.IsNullOrWhiteSpace(cpfcnpj) || CpfValidator.ValidateCpf(cpfcnpj))
               .WithMessage("CPF informado não é válido");
    }
}
