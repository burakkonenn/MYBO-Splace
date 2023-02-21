using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DTOs.Language;
using Web.Application.DTOs.Link;
using Web.Shared;

namespace Web.Application.Abstractions.Services.Link
{
    public interface ILinkService
    {
        Task<Response<Domain.Entities.Brief.Link>> CreateAsync(CreateLink model);
        Task<Response<Domain.Entities.Brief.Link>> GetUpdateAsync(Guid? id);
        Task<Response<Domain.Entities.Brief.Link>> PostUpdateAsync(PostUpdateLink model);
    }
}
