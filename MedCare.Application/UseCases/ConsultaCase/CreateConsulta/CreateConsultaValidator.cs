using FluentValidation;

namespace MedCare.Application.UseCases.ConsultaCase.CreateConsulta;

public class CreateConsultaValidator : AbstractValidator<CreateConsultaRequest>
{
    public CreateConsultaValidator()
    {
        RuleFor(p => p.pacienteid).GreaterThan(0).WithMessage("Informe o paciente");
        RuleFor(p => p.funcionarioid).GreaterThan(0).WithMessage("Informe o funcionário");
        RuleFor(p => p.especialidade).MinimumLength(1).MaximumLength(100);
        RuleFor(p => p.diagnostico).MinimumLength(1).WithMessage("Informe o diágnostico");
    }
}
