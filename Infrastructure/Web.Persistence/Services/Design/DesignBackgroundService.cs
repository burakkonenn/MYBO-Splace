using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Abstractions.Services.Design;
using Web.Application.DTOs.Design.DesignBackground;
using Web.Application.DTOs.User;
using Web.Domain.Entities.Design;
using Web.Domain.Entities.Identity;
using Web.Persistence.Contexts;
using Web.Shared;

namespace Web.Persistence.Services.Design
{
    public class DesignBackgroundService : IDesignBackgroundService
    {

        private readonly SplaceDbContext _context;

        public DesignBackgroundService(SplaceDbContext context)
        {
            _context = context; 
        }

        public async Task<Response<Domain.Entities.Design.DesignBackground>> CreateAsync(CreateDesignBackground model)
        {

            var desingBackground = new Web.Domain.Entities.Design.DesignBackground()
            {
                Title = model.Title,
                Wallpaper = model.Wallpaper,
                GradientType = model.GradientType,
                GradientColor1 = model.GradientColor1,
                GradientColor2 = model.GradientColor2,
                IsSystem = model.IsSystem,
            };

            await _context.DesignBackgrounds.AddAsync(desingBackground);
            await _context.SaveChangesAsync();

            return Response<Domain.Entities.Design.DesignBackground>.Success(desingBackground, 200, 1);
        }

        public async Task<Response<GetUpdateDesignBackground>> GetUpdateAsync(Guid? id)
        {
            if (id == null)
            {
                return Response<GetUpdateDesignBackground>.Fail($"{id} bilgisi null", 400);
            }

            var designBackground = await _context.DesignBackgrounds.Where(a => a.Id == id).Select(a => new GetUpdateDesignBackground()
            {
                Title = a.Title,
                Wallpaper = a.Wallpaper,
                GradientType = a.GradientType,
                BackgroundColor = a.BackgroundColor,
                GradientColor1 = a.GradientColor1,
                GradientColor2 = a.GradientColor2

            }).FirstOrDefaultAsync();
            if (designBackground == null)
            {
                return Response<GetUpdateDesignBackground>.Fail($"{designBackground} bilgisi null", 400);
            }

            return Response<GetUpdateDesignBackground>.Success(designBackground, 200, 1);
        }

        public async Task<Response<Domain.Entities.Design.DesignBackground>> PostUpdateAsync(PostUpdateDesignBackground model)
        {
            var desingBackground = await _context.DesignBackgrounds.FindAsync(model.DesignBackgroundId);
            if(desingBackground == null)
            {
               return Response<Domain.Entities.Design.DesignBackground>.Fail("hata", 400);
            }

            desingBackground.Wallpaper = model.Wallpaper;
            desingBackground.Title= model.Title;
            desingBackground.GradientType = model.GradientType;
            desingBackground.GradientColor1 = model.GradientColor1;
            desingBackground.GradientColor2 = model.GradientColor2;
            desingBackground.BackgroundColor= model.BackgroundColor;
            desingBackground.IsSystem = model.IsSystem;

            await _context.SaveChangesAsync();
            return Response<Domain.Entities.Design.DesignBackground>.Success(desingBackground, 200, 1);

        }



    }
}
