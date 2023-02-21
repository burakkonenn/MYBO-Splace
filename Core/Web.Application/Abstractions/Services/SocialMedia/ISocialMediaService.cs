using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.DTOs.SocialMedia;
using Web.Application.DTOs.Words;
using Web.Shared;

namespace Web.Application.Abstractions.Services.SocialMedia
{
    public interface ISocialMediaService
    {
        Task<Response<Domain.Entities.Design.SocialMedia>> CreateAsync(CreateSocialMedia model);
        Task<Response<Domain.Entities.Design.SocialMedia>> GetUpdateAsync(Guid? id);
        Task<Response<Domain.Entities.Design.SocialMedia>> PostUpdateAsync(PostUpdateSocialMedia model);
    }
}
