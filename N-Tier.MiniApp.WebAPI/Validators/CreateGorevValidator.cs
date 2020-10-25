using FluentValidation;
using N_Tier.MiniApp.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.WebAPI.Validators
{
    public class CreateGorevValidator : AbstractValidator<CreateGorevDTO>
    {

        public CreateGorevValidator()
        {
            RuleFor(a => a.Gorevadi).NotEmpty().WithMessage("Görev adı boş olmamalı");
            RuleFor(a => a.Gorevtanimi).NotEmpty().WithMessage("Görev tanımı boş olmamalı");
        }
    }
}
