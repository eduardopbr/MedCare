using FluentValidation;

namespace MedCare.Application.UseCases.ConsultaCase.UpdateConsulta;

public class UpdateConsultaValidator : AbstractValidator<UpdateConsultaRequest>
{
    public UpdateConsultaValidator()
    {
        RuleFor(p => p.id).GreaterThan(0).WithMessage("Informe o ID da consulta que deseja atualizar");
        RuleFor(p => p.pacienteid).GreaterThan(0).WithMessage("Informe o paciente");
        RuleFor(p => p.funcionarioid).GreaterThan(0).WithMessage("Informe o funcionário");
        RuleFor(p => p.especialidade).MinimumLength(1).MaximumLength(100);
        RuleFor(p => p.diagnostico).MinimumLength(1).WithMessage("Informe o diágnostico");
    }
}
