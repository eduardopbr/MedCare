using FluentValidation;
using MedCare.Application.Shared.Validators;

namespace MedCare.Application.UseCases.PacienteCase.UpdatePaciente;

public class UpdatePacienteValidator : AbstractValidator<UpdatePacienteRequest>
{
    public UpdatePacienteValidator()
    {
        RuleFor(x => x.email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(x => x.id).GreaterThan(0).WithMessage("Informe um ID maior que 0");
        RuleFor(x => x.cpf)
               .Cascade(CascadeMode.Stop)
               .Must(cpfcnpj => string.IsNullOrWhiteSpace(cpfcnpj) || CpfValidator.ValidateCpf(cpfcnpj))
                   .WithMessage("CPF informado não é válido");
    }
}
