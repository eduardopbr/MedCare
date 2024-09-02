using FluentValidation;

namespace MedCare.Application.UseCases.ProcedimentoCase.CreateProcedimento;

public class CreateProcedimentoValidator : AbstractValidator<CreateProcedimentoRequest>
{
    public CreateProcedimentoValidator()
    {
        RuleFor(p => p.pacienteid).GreaterThan(0).WithMessage("Informe o paciente");
        RuleFor(p => p.funcionarioid).GreaterThan(0).WithMessage("Informe o funcionário");
        RuleFor(p => p.tipo).MinimumLength(1).MaximumLength(50);
    }
}
