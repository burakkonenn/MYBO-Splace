using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Abstractions.Services.Design;
using Web.Application.DTOs.Design.DesignBackground;
using Web.Application.DTOs.Design.DesignButton;
using Web.Domain.Entities.Design;
using Web.Persistence.Contexts;
using Web.Shared;

namespace Web.Persistence.Services.Design
{
    public class DesignButtonService : IDesignButtonService
    {
        private readonly SplaceDbContext _context;
        public DesignButtonService(SplaceDbContext context)
        {
            _context = context;
        }

        public async Task<Response<Domain.Entities.Design.DesignButton>> CreateAsync(CreateDesignButton model)
        {
            var designButton = new Domain.Entities.Design.DesignButton()
            {
                Title = model.Title,
                TextColor = model.TextColor,
                BgColor = model.BgColor,
                BorderColor = model.BorderColor,
                ShadowColor = model.ShadowColor,
                IsSystem = true
            };

            await _context.DesignButtons.AddAsync(designButton);
            await _context.SaveChangesAsync();

            return Response<Domain.Entities.Design.DesignButton>.Success(designButton, 200, 1);
        }

        public async Task<Response<GetUpdateDesignButton>> GetUpdateAsync(Guid? id)
        {
            if (id == null)
            {
                return Response<GetUpdateDesignButton>.Fail($"{id} bilgisi null", 400);
            }

            var designButton = await _context.DesignButtons.Where(a => a.Id == id).Select(a => new GetUpdateDesignButton()
            {
                Title = a.Title,
                TextColor = a.TextColor,
                BgColor = a.BgColor,
                BorderColor = a.BorderColor,
                ShadowColor = a.ShadowColor,

            }).FirstOrDefaultAsync();

            if (designButton == null)
            {
                return Response<GetUpdateDesignButton>.Fail($"{designButton} bilgisi null", 400);
            }

            return Response<GetUpdateDesignButton>.Success(designButton, 200, 1);
        }

        public async Task<Response<Domain.Entities.Design.DesignButton>> PostUpdateAsync(PostUpdateDesignButton model)
        {

            if(model.DesignButtonId == null)
            {
                return Response<Domain.Entities.Design.DesignButton>.Fail($"{model.DesignButtonId} null", 400);

            }
            var designButton = await _context.DesignButtons.FindAsync(model.DesignButtonId);
            if(designButton== null)
            {
                return Response<Domain.Entities.Design.DesignButton>.Fail($"{model.DesignButtonId}'li bilgiler null", 400);
            }

            designButton.Title = model.Title;
            designButton.TextColor = model.TextColor;   
            designButton.BorderColor = model.BorderColor;
            designButton.ShadowColor = model.ShadowColor;
            designButton.BgColor = model.BgColor;
            designButton.IsSystem = model.IsSystem;

            await _context.SaveChangesAsync();
            return Response<Domain.Entities.Design.DesignButton>.Success(designButton, 200, 1);
        }
    }
}
