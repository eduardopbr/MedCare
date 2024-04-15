using FluentValidation;
using MedCare.Application.UseCases.FuncionarioCase.CreateFuncionario;

namespace MedCare.Application.UseCases.FuncionarioCase.UpdateFuncionario
{
    public class UpdateFuncionarioValidator : AbstractValidator<CreateFuncionarioRequest>
    {
        public UpdateFuncionarioValidator()
        {
            RuleFor(x => x.email).NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.nome).NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}
