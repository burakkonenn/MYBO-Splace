using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DTOs.Language;

namespace Web.Application.Validators.Language
{
    public class PostUpdateLanguageValidator: AbstractValidator<PostUpdateLanguage>
    {
        public PostUpdateLanguageValidator()
        {
            RuleFor(u => u.LangName)
          .NotEmpty()
          .NotNull().WithMessage("Lütfen isim alanını boş bırakmayınız")
          .MaximumLength(15)
          .MinimumLength(3).WithMessage("Lütfen başlık alanını 3 ile 30 karakter arasında giriniz");

            RuleFor(u => u.LangCode)
             .NotEmpty()
             .NotNull();

            RuleFor(u => u.IsRtl)
               .NotEmpty()
               .NotNull();

        }
    }
}
