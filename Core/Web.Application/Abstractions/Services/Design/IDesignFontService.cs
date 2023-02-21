using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DTOs.Design.DesignBackground;
using Web.Application.DTOs.Design.DesignFont;
using Web.Domain.Entities.Design;
using Web.Shared;

namespace Web.Application.Abstractions.Services.Design
{
    public interface IDesignFontService
    {
        Task<Response<DesignFont>> CreateAsync(CreateDesignFont model);
        Task<Response<DesignFont>> GetUpdateAsync(Guid? id);
        Task<Response<DesignFont>> PostUpdateAsync(PostUpdateDesignFont model);
    }
}
