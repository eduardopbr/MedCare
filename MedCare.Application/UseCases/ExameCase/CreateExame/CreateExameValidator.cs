using FluentValidation;

namespace MedCare.Application.UseCases.ExameCase.CreateExame;

public class CreateExameValidator : AbstractValidator<CreateExameRequest>
{
    public CreateExameValidator()
    {
        RuleFor(p => p.pacienteid).GreaterThan(0).WithMessage("Informe o paciente");
        RuleFor(p => p.tipo).MinimumLength(1).MaximumLength(50);
    }
}
