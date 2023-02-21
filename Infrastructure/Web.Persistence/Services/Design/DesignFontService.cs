using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Abstractions.Services.Design;
using Web.Application.DTOs.Design.DesignButton;
using Web.Application.DTOs.Design.DesignFont;
using Web.Persistence.Contexts;
using Web.Shared;

namespace Web.Persistence.Services.Design
{
    public class DesignFontService : IDesignFontService
    {
        private readonly SplaceDbContext _context;
        public DesignFontService(SplaceDbContext context)
        {
            _context = context;
        }
        public async Task<Response<Domain.Entities.Design.DesignFont>> CreateAsync(CreateDesignFont model)
        {
            var designFont = new Domain.Entities.Design.DesignFont()
            {
                Name = model.Name,
                FontFamily = model.FontFamily,
                FontSrc = model.FontSrc,
            };

            await _context.DesignFonts.AddAsync(designFont);
            await _context.SaveChangesAsync();

            return Response<Domain.Entities.Design.DesignFont>.Success(designFont, 200, 1);
        }

        public async Task<Response<Domain.Entities.Design.DesignFont>> GetUpdateAsync(Guid? id)
        {
            if (id == null)
            {
                return Response<Domain.Entities.Design.DesignFont>.Fail($"{id} bilgisi null", 400);
            }

            var designFont = await _context.DesignFonts.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (designFont == null)
            {
                return Response<Domain.Entities.Design.DesignFont>.Fail($"{designFont} bilgisi null", 400);
            }

            return Response<Domain.Entities.Design.DesignFont>.Success(designFont, 200, 1);
        }

        public async Task<Response<Domain.Entities.Design.DesignFont>> PostUpdateAsync(PostUpdateDesignFont model)
        {
            if(model.DesignFontId == null)
            {
                Response<Domain.Entities.Design.DesignFont>.Fail($"{model.DesignFontId} null", 400);
            }

            var designFont = await _context.DesignFonts.FindAsync(model.DesignFontId);
            if(designFont == null)
            {
                Response<Domain.Entities.Design.DesignFont>.Fail($"{model.DesignFontId} kayıtlı bilgi null", 400);
            }

            designFont.Name = model.Name;
            designFont.FontSrc = model.FontSrc;
            designFont.FontFamily = model.FontFamily;

            await _context.SaveChangesAsync();
            return Response<Domain.Entities.Design.DesignFont>.Success(designFont, 200, 1);
        }
    }
}
