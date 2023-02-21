using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DTOs.Design.DesignButton;

namespace Web.Application.Validators.DesignButton
{
    public class CreateDesignButtonValidator : AbstractValidator<CreateDesignButton>
    {
        public CreateDesignButtonValidator()
        {
            RuleFor(u => u.Title)
             .NotEmpty()
             .NotNull().WithMessage("Lütfen başlık alanını boş bırakmayınız")
             .MaximumLength(15)
             .MinimumLength(3).WithMessage("Lütfen başlık alanını 3 ile 20 karakter arasında giriniz");

            RuleFor(u => u.TextColor)
             .NotEmpty()
             .NotNull().WithMessage("Lütfen yazı rengi alanını boş bırakmayınız");

            RuleFor(u => u.BgColor)
               .NotEmpty()
               .NotNull().WithMessage("Lütfen arka plan rengi alanını boş bırakmayınız");

            RuleFor(b => b.ShadowColor)
               .NotEmpty()
               .NotNull();

            RuleFor(u => u.BorderColor)
               .NotEmpty()
               .NotNull();
        }
    }
}
