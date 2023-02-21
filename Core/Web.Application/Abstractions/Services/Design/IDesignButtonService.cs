using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DTOs.Design.DesignBackground;
using Web.Application.DTOs.Design.DesignButton;
using Web.Domain.Entities.Design;
using Web.Shared;

namespace Web.Application.Abstractions.Services.Design
{
    public interface IDesignButtonService
    {
        Task<Response<DesignButton>> CreateAsync(CreateDesignButton model);
        Task<Response<GetUpdateDesignButton>> GetUpdateAsync(Guid? id);
        Task<Response<DesignButton>> PostUpdateAsync(PostUpdateDesignButton model);
    }
}
