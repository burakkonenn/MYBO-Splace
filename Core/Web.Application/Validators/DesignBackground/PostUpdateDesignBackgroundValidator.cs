using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DTOs.Design.DesignBackground;

namespace Web.Application.Validators.DesignBackground
{
    public class PostUpdateDesignBackgroundValidator: AbstractValidator<PostUpdateDesignBackground>
    {
        public PostUpdateDesignBackgroundValidator()
        {
            RuleFor(n => n.Title)
              .NotEmpty()
              .NotNull().WithMessage("Lütfen başlık alanını boş bırakmayınız")
              .MaximumLength(50)
              .MinimumLength(3).WithMessage("Lütfen isim alanı 3 ile 100 karakter arasında giriniz");

            RuleFor(s => s.Wallpaper)
                .NotEmpty()
                .NotNull().WithMessage("Lütfen arka plan alanını boş bırakmayınız");

            RuleFor(s => s.GradientType)
                .NotEmpty()
                .NotNull();

            RuleFor(s => s.BackgroundColor)
              .NotEmpty()
              .NotNull();

            RuleFor(u => u.GradientColor1)
              .NotEmpty();

            RuleFor(b => b.GradientColor1)
               .NotEmpty()
               .NotNull();
        }
    }
}
