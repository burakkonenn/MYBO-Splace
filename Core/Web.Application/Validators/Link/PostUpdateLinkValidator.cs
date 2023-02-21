using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DTOs.Link;

namespace Web.Application.Validators.Link
{
    public class PostUpdateLinkValidator : AbstractValidator<PostUpdateLink>
    {
        public PostUpdateLinkValidator()
        {
            RuleFor(u => u.Title)
              .NotEmpty()
              .NotNull().WithMessage("Lütfen isim alanını boş bırakmayınız")
              .MaximumLength(15)
              .MinimumLength(3).WithMessage("Lütfen başlık alanını 3 ile 50 karakter arasında giriniz");

            RuleFor(u => u.Avatar)
             .NotEmpty()
             .NotNull();

            RuleFor(u => u.Url)
                 .NotNull().WithMessage("Lütfen url alanını boş bırakmayınız");
        }
    }
}
