using FluentValidation;

namespace MedCare.Application.UseCases.FuncionarioCase.CreateFuncionario
{
    public class CreateFuncionarioValidator : AbstractValidator<CreateFuncionarioRequest>
    {
        public CreateFuncionarioValidator()
        {
            RuleFor(x => x.email).NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.nome).NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}
