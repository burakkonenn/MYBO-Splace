using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Application.Abstractions.Services.User;
using Web.Application.DTOs.User;
using Web.Domain.Entities.Identity;
using Web.Persistence.Contexts;
using Web.Shared;

namespace Web.Persistence.Services.User
{
    public class UserService : IUserService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SplaceDbContext _context;
        private readonly IEmailSender _emailSender;
        public IUrlHelper Url { get; set; }

        public UserService(UserManager<AppUser> userManager, SplaceDbContext context)
        {
            _userManager = userManager;
            _context = context;
            
        }

        public async Task<Response<AppUser>> CreateAsync(CreateUser model)
        {
            var user = new AppUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.UserName,
                Email = model.Email,
                Biography = model.Biography,
                Slug = model.Slug,
                Avatar = model.Avatar,
                FacebookConversionId = model.FacebookConversionId,
                GoogleAnalyticsId = model.GoogleAnalyticsId,
                FacebookPixelId= model.FacebookPixelId,
                Famous = model.Famous,
                MetaDescription = model.MetaDescription,
                MetaTitle= model.MetaTitle,
                AccountType = model.AccountType,
                DesignBackgroundId= model.DesignBackgroundId,
                DesignButtonId= model.DesignButtonId,
                DesignFontId= model.DesignFontId,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Response<AppUser>.Success(user, 200, 1);
            }


            List<string> errors = new List<string>();

            var userNameCheck = await _context.Users.Where(a => a.UserName == model.UserName).FirstOrDefaultAsync();
            if (userNameCheck != null)
            {
                errors.Add("Kullanıcı adı kayıtlı, lütfen başka bir kullanıcı adı belirtiniz");
            }

            var emailCheck = await _context.Users.Where(a => a.Email == model.Email).FirstOrDefaultAsync();
            if (emailCheck != null)
            {
                errors.Add("Email adresi kayıtlı");
            }

            return Response<AppUser>.Fail(errors, 400);
        }

        public async Task<Response<AppUser>> UpdateAsync(UpdateUser model)
        {

            var user = await _context.Users.FindAsync(model.Id);
            if(user != null)
            {
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.Biography = model.Biography;
                user.Avatar = model.Avatar;
                user.Slug = model.Slug;

                await _context.SaveChangesAsync();
                return Response<AppUser>.Success(user, 200, 1);
            }

            return Response<AppUser>.Fail("hata oluştu", 400);


        }

        public async Task<Response<List<GetAllUser>>> GetAllAsync()
        {
            var users = await _context.Users.Select(a => new GetAllUser()
            {
                Name = a.Name,
                Surname = a.Surname,
                Email = a.Email,
                Avatar = a.Avatar,
                UserName = a.UserName,

            }).ToListAsync();

            if(users == null)
            {
                return Response<List<GetAllUser>>.Fail("Kullanıcı kayıtları bulunmamaktadır", 400);
            }

            return Response<List<GetAllUser>>.Success(users, 200, 1);
        }

        public async Task<Response<GetSingleUser>> GetByIdSingle(Guid? id)
        {
            if (id == null)
            {
                Response<GetSingleUser>.Fail($"{id} kayıtlı kullanıcı bulunmamaktadır", 400);
            }

            var user = await _context.Users.Select(a => new GetSingleUser()
            {
                Name = a.Name,
                Surname = a.Surname,
                Email = a.Email,
                UserName = a.UserName,
                Avatar = a.Avatar,

            }).FirstOrDefaultAsync();

            return Response<GetSingleUser>.Success(user, 200, 1);
        }

      
    }
}
