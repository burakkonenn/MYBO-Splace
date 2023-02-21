using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DTOs.Design.DesignFont;

namespace Web.Application.Validators.DesignFont
{
    public class CreateDesignFontValidator: AbstractValidator<CreateDesignFont>
    {
        public CreateDesignFontValidator()
        {
            RuleFor(u => u.Name)
            .NotEmpty()
            .NotNull().WithMessage("Lütfen isim alanını boş bırakmayınız")
            .MaximumLength(15)
            .MinimumLength(3).WithMessage("Lütfen başlık alanını 3 ile 20 karakter arasında giriniz");

            RuleFor(u => u.FontFamily)
             .NotEmpty()
             .NotNull().WithMessage("Lütfen yazı stilini boş bırakmayınız");

            RuleFor(u => u.FontSrc)
               .NotEmpty()
               .NotNull();

        }
    }
}
