using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DTOs.Words;

namespace Web.Application.Validators.Word
{
    public class CreateWordValidator : AbstractValidator<CreateWord>
    {
        public CreateWordValidator() 
        {
            RuleFor(u => u.WordValue)
            .NotEmpty()
            .NotNull().WithMessage("Lütfen kelime değerini boş bırakmayınız")
            .MaximumLength(15)
            .MinimumLength(3).WithMessage("Lütfen isim alanını 3 ile 50 karakter arasında giriniz");

            RuleFor(u => u.WordKey)
             .NotEmpty()
             .NotNull().WithMessage("Lütfen anathar kelimeyi boş bırakmayınız")
             .MaximumLength(15)
             .MinimumLength(3).WithMessage("Lütfen soyisim alanını 3 ile 30 karakter arasında giriniz");

            RuleFor(u => u.LanguageId)
            .NotEmpty()
            .NotNull().WithMessage("Lütfen dil seçmeyi unutmayınız");
        }
    }
}
