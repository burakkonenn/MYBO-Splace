using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DTOs.User;
using Web.Domain.Entities.Identity;
using Web.Shared;

namespace Web.Application.Abstractions.Services.Auth
{
    public interface IAuthService
    {
        Task<Response<AppUser>> ResetPasswordAsync(string email);
        Task<Response<AppUser>> VerifyResetPasswordAsync();
        Task<Response<AppUser>> ForgotPasswordAsync(string email);
    }
}
