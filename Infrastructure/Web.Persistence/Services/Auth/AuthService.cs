using Microsoft.AspNetCore.Identity;
using Web.Application.Abstractions.Services.Auth;
using Web.Application.DTOs.User;
using Web.Domain.Entities.Identity;
using Web.Persistence.Contexts;
using Web.Shared;

namespace Web.Persistence.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SplaceDbContext _context;

        public AuthService(UserManager<AppUser> userManager, SplaceDbContext context)
        {
            _userManager = userManager;
            _context = context;

        }

        public Task<Response<AppUser>> ForgotPasswordAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Response<AppUser>> ResetPasswordAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Response<AppUser>> VerifyResetPasswordAsync()
        {
            throw new NotImplementedException();
        }
    }
}
