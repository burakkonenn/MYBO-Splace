using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Abstractions.Services.SocialMedia;
using Web.Application.DTOs.SocialMedia;
using Web.Domain.Entities.Design;
using Web.Persistence.Contexts;
using Web.Shared;

namespace Web.Persistence.Services.SocialMedia
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly SplaceDbContext _context;
        public SocialMediaService(SplaceDbContext context)
        {
            _context = context;
        }
    
        public async Task<Response<Domain.Entities.Design.SocialMedia>> CreateAsync(CreateSocialMedia model)
        {
            var socialMedia = new Domain.Entities.Design.SocialMedia()
            {
                Title = model.Title,
                Url = model.Url,
                Platform = model.Platform,
                AppUserId  = model.AppUserId,
            };

            await _context.SocialMedias.AddAsync(socialMedia);
            await _context.SaveChangesAsync();

            return Response<Domain.Entities.Design.SocialMedia>.Success(socialMedia, 200, 1);
        }

        public async Task<Response<Domain.Entities.Design.SocialMedia>> GetUpdateAsync(Guid? id)
        {
            if(id == null)
            {
                Response<Domain.Entities.Design.SocialMedia>.Fail($"{id} bilgisi null", 400);
            }

            var socialMedia = await _context.SocialMedias.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (socialMedia == null)
            {
                Response<Domain.Entities.Design.SocialMedia>.Fail($"{socialMedia} bilgisi null", 400);
            }

            return Response<Domain.Entities.Design.SocialMedia>.Success(socialMedia, 200, 1);
        }

        public async Task<Response<Domain.Entities.Design.SocialMedia>> PostUpdateAsync(PostUpdateSocialMedia model)
        {
            if (model.SocialMediaId == null)
            {
                Response<Domain.Entities.Design.SocialMedia>.Fail($"{model.SocialMediaId} bilgisi null", 400);
            }

            var socialMedia = await _context.SocialMedias.FindAsync(model.SocialMediaId);
            if (socialMedia == null)
            {
                Response<Domain.Entities.Design.SocialMedia>.Fail($"{socialMedia} bilgisi null", 400);
            }

            socialMedia.Title = model.Title;
            socialMedia.Platform = model.Platform;
            socialMedia.Url = model.Url;

            await _context.SaveChangesAsync();
            return Response<Domain.Entities.Design.SocialMedia>.Success(socialMedia, 200, 1);
        }
    }
}
