using FluentValidation;

namespace MedCare.Application.UseCases.ExameCase.UpdateExame;

public class UpdateExameValidator : AbstractValidator<UpdateExameRequest>
{
    public UpdateExameValidator()
    {
        RuleFor(p => p.id).GreaterThan(0).WithMessage("Informe o ID do exame que deseja atualizar");
        RuleFor(p => p.pacienteid).GreaterThan(0).WithMessage("Informe o paciente");
        RuleFor(p => p.tipo).MinimumLength(1).MaximumLength(50);
    }
}
