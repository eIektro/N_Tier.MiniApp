using FluentValidation;
using N_Tier.MiniApp.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.WebAPI.Validators
{
    public class CreateSirketValidator : AbstractValidator<CreateSirketDTO>
    {
        public CreateSirketValidator()
        {
            RuleFor(a => a.Sirketadi).NotEmpty().WithMessage("Şirket adı boş olmamalı");
            RuleFor(a => a.Unvan).NotEmpty().WithMessage("Şirket ünvanı boş olmamalı");
        }
    }
}
