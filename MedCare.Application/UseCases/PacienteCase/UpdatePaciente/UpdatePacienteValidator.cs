﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Application.UseCases.PacienteCase.UpdatePaciente
{
    public class UpdatePacienteValidator : AbstractValidator<UpdatePacienteRequest>
    {
        public UpdatePacienteValidator()
        {

        }
    }
}
