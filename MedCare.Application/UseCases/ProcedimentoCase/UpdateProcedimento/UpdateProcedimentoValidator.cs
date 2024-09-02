using FluentValidation;

namespace MedCare.Application.UseCases.ProcedimentoCase.UpdateProcedimento;

public class UpdateProcedimentoValidator : AbstractValidator<UpdateProcedimentoRequest>
{
    public UpdateProcedimentoValidator()
    {
        RuleFor(p => p.procedimentoid).GreaterThan(0).WithMessage("Informe o ID do procedimento que deseja atualizar");
        RuleFor(p => p.pacienteid).GreaterThan(0).WithMessage("Informe o paciente");
        RuleFor(p => p.funcionarioid).GreaterThan(0).WithMessage("Informe o funcionário");
        RuleFor(p => p.tipo).MinimumLength(1).MaximumLength(50);
    }
}
