using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DTOs.Language;
using Web.Application.DTOs.Words;
using Web.Shared;

namespace Web.Application.Abstractions.Services.Words
{
    public interface IWordsService
    {
        Task<Response<Domain.Entities.Culture.Word>> CreateAsync(CreateWord model);
        Task<Response<Domain.Entities.Culture.Word>> GetUpdateAsync(Guid? id);
        Task<Response<Domain.Entities.Culture.Word>> PostUpdateAsync(PostUpdateWord model);
    }
}
