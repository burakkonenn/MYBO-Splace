using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DTOs.User;
using Web.Domain.Entities.Identity;
using Web.Shared;

namespace Web.Application.Abstractions.Services.User
{
    public interface IUserService
    {
        Task<Response<AppUser>> CreateAsync(CreateUser model);
        Task<Response<AppUser>> UpdateAsync(UpdateUser model);
        Task<Response<List<GetAllUser>>> GetAllAsync();
        Task<Response<GetSingleUser>> GetByIdSingle(Guid? id);
       

    }
}
