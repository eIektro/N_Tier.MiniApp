using FluentValidation;
using N_Tier.MiniApp.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.WebAPI.Validators
{
    public class CreateKullaniciValidator :AbstractValidator<CreateKullaniciDTO>
    {

        //TO-DO: Kullanıcı silme, güncelleme işlemleri için de validation kurallarımı oluşturmalıyım.
        public CreateKullaniciValidator()
        {
            
            //TO-DO: Foreign Key kısıtlamaları için de validasyon yapılacak

            RuleFor(a => a.Isim).NotEmpty().WithMessage("İsim boş olmamalı");
            RuleFor(a => a.Soyisim).NotEmpty().WithMessage("Soyisim boş olmamalı");

        }

    }
}
