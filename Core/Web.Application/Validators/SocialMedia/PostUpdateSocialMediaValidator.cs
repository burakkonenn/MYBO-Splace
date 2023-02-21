using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DTOs.SocialMedia;

namespace Web.Application.Validators.SocialMedia
{
    public class PostUpdateSocialMediaValidator : AbstractValidator<PostUpdateSocialMedia>
    {
        public PostUpdateSocialMediaValidator()
        {
            RuleFor(u => u.Title)
               .NotEmpty()
               .NotNull().WithMessage("Lütfen başlık alanını boş bırakmayınız")
               .MaximumLength(15)
               .MinimumLength(3).WithMessage("Lütfen başlık alanını 3 ile 50 karakter arasında giriniz");

            RuleFor(u => u.Url)
             .NotEmpty()
             .NotNull().WithMessage("Lütfen url alanını boş bırakmayınız")
             .MaximumLength(15)
             .MinimumLength(3).WithMessage("Lütfen başlık alanını 3 ile 50 karakter arasında giriniz");

            RuleFor(u => u.Platform)
            .NotEmpty()
            .NotNull().WithMessage("Lütfen platform alanını boş bırakmayınız")
            .MaximumLength(15)
            .MinimumLength(3).WithMessage("Lütfen başlık alanını 3 ile 50 karakter arasında giriniz");
        }
    }
}
