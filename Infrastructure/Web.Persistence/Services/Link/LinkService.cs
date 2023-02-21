using Microsoft.EntityFrameworkCore;
using Web.Application.Abstractions.Services.Link;
using Web.Application.DTOs.Language;
using Web.Application.DTOs.Link;
using Web.Persistence.Contexts;
using Web.Shared;

namespace Web.Persistence.Services.Link
{
    public class LinkService : ILinkService
    {
        private readonly SplaceDbContext _context;
        public async Task<Response<Domain.Entities.Brief.Link>> CreateAsync(CreateLink model)
        {
            var Link = new Domain.Entities.Brief.Link()
            {
                Title = model.Title,
                Avatar = model.Avatar,
                Url = model.Url,
                IsSensitive = model.IsSensitive,
                IsTimer = model.IsTimer,
                ListNumber = model.ListNumber,
                StartTimer = model.StartTimer,
                FinishTimer = model.FinishTimer,
                AppUserId = model.AppUserId,
            };

            await _context.Links.AddAsync(Link);
            await _context.SaveChangesAsync();

            return Response<Domain.Entities.Brief.Link>.Success(Link, 200, 1);
        }

        public async Task<Response<Domain.Entities.Brief.Link>> GetUpdateAsync(Guid? id)
        {
            if (id == null)
            {
                return Response<Domain.Entities.Brief.Link>.Fail($"{id} bilgisi null", 400);
            }

            var link = await _context.Links.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (link == null)
            {
                return Response<Domain.Entities.Brief.Link>.Fail($"{link} bilgisi null", 400);
            }

            return Response<Domain.Entities.Brief.Link>.Success(link, 200, 1);
        }

        public async Task<Response<Domain.Entities.Brief.Link>> PostUpdateAsync(PostUpdateLink model)
        {
            if (model.LinkId == null)
            {
                return Response<Domain.Entities.Brief.Link>.Fail($"{model.LinkId} null", 400);

            }
            var link = await _context.Links.FindAsync(model.LinkId);
            if (link == null)
            {
                return Response<Domain.Entities.Brief.Link>.Fail($"{model.LinkId}'li bilgiler null", 400);
            }

            link.Avatar = model.Avatar;
            link.Title = model.Title;
            link.Url = model.Url;
            link.StartTimer = model.StartTimer;
            link.FinishTimer = model.FinishTimer;
            link.IsSensitive = model.IsSensitive;
            link.IsTimer = model.IsTimer;
            link.ListNumber = model.ListNumber;

            await _context.SaveChangesAsync();
            return Response<Domain.Entities.Brief.Link>.Success(link, 200, 1);
        }
    }
}
