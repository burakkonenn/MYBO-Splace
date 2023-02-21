using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DTOs.Language;
using Web.Application.DTOs.User;
using Web.Domain.Entities.Identity;
using Web.Shared;

namespace Web.Application.Abstractions.Services.Language
{
    public interface ILanguageService
    {
        Task<Response<Domain.Entities.Culture.Language>> CreateAsync(CreateLanguage model);
        Task<Response<Domain.Entities.Culture.Language>> GetUpdateAsync(Guid? id);
        Task<Response<Domain.Entities.Culture.Language>> PostUpdateAsync(PostUpdateLanguage model);
    }
}
