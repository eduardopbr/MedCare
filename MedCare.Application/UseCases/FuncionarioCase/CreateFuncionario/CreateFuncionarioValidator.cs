﻿using FluentValidation;
using MedCare.Application.Shared.Validators;

namespace MedCare.Application.UseCases.FuncionarioCase.CreateFuncionario
{
    public class CreateFuncionarioValidator : AbstractValidator<CreateFuncionarioRequest>
    {
        public CreateFuncionarioValidator()
        {
            RuleFor(x => x.email).NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.nome).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.cpf)
           .Cascade(CascadeMode.Stop)
           .Must(cpfcnpj => string.IsNullOrWhiteSpace(cpfcnpj) || CpfValidator.ValidateCpf(cpfcnpj))
               .WithMessage("CPF informado não é válido");
        }
    }
}
