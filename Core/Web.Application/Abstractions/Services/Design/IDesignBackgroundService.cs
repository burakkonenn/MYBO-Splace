using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DTOs.Design.DesignBackground;
using Web.Application.DTOs.User;
using Web.Domain.Entities.Design;
using Web.Domain.Entities.Identity;
using Web.Shared;

namespace Web.Application.Abstractions.Services.Design
{
    public interface IDesignBackgroundService
    {
        Task<Response<DesignBackground>> CreateAsync(CreateDesignBackground model);
        Task<Response<GetUpdateDesignBackground>> GetUpdateAsync(Guid? id);
        Task<Response<DesignBackground>> PostUpdateAsync(PostUpdateDesignBackground model);

    }
}
