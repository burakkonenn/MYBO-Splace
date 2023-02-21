using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DTOs.User;

namespace Web.Application.Validators.Users
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {

            RuleFor(u => u.Name)
              .NotEmpty()
              .NotNull().WithMessage("Lütfen isim alanını boş bırakmayınız")
              .MaximumLength(15)
              .MinimumLength(3).WithMessage("Lütfen isim alanını 3 ile 20 karakter arasında giriniz");

            RuleFor(u => u.Surname)
             .NotEmpty()
             .NotNull().WithMessage("Lütfen soyisim alanını boş bırakmayınız")
             .MaximumLength(15)
             .MinimumLength(3).WithMessage("Lütfen soyisim alanını 3 ile 30 karakter arasında giriniz");

            RuleFor(u => u.UserName)
               .NotEmpty()
               .NotNull().WithMessage("Lütfen kullanıcı adı alanını boş bırakmayınız")
               .MaximumLength(15)
               .MinimumLength(3).WithMessage("Lütfen kullanıcı adı alanını 3 ile 15 karakter arasında giriniz");

            RuleFor(b => b.Email)
               .NotEmpty()
               .NotNull().WithMessage("Lütfen email alanını boş bırakmayınız");

            RuleFor(u => u.Biography)
               .NotEmpty()
               .NotNull().WithMessage("Lütfen biyografi alanını boş bırakmayınız")
               .MaximumLength(15)
               .MinimumLength(3).WithMessage("Lütfen kullanıcı adı alanını 3 ile 15 karakter arasında giriniz");

            RuleFor(u => u.Avatar)
              .NotEmpty()
              .NotNull().WithMessage("Lütfen avatar alanını boş bırakmayınız");

            RuleFor(u => u.Slug)
            .NotEmpty()
            .NotNull().WithMessage("Lütfen slug alanını boş bırakmayınız");

            RuleFor(p => p.Password)
             .NotEmpty()
             .NotNull().WithMessage("Lütfen parola alanını boş bırakmayınız");


        }
    }
}
