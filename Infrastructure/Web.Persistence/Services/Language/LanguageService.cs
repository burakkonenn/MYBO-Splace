using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Abstractions.Services.Language;
using Web.Application.DTOs.Design.DesignButton;
using Web.Application.DTOs.Language;
using Web.Domain.Entities.Culture;
using Web.Persistence.Contexts;
using Web.Shared;

namespace Web.Persistence.Services.Language
{
    public class LanguageService : ILanguageService
    {

        private readonly SplaceDbContext _context;
        public LanguageService(SplaceDbContext context)
        {
           _context = context;
        }
        public async Task<Response<Domain.Entities.Culture.Language>> CreateAsync(CreateLanguage model)
        {
            var language = new Domain.Entities.Culture.Language()
            {
                LangName = model.LangName,
                LangCode = model.LangCode,
                IsRtl = model.IsRtl,

            };

            await _context.Languages.AddAsync(language);
            await _context.SaveChangesAsync();

            return Response<Domain.Entities.Culture.Language>.Success(language, 200, 1);
        }

        public async Task<Response<Domain.Entities.Culture.Language>> GetUpdateAsync(Guid? id)
        {
            if (id == null)
            {
                return Response<Domain.Entities.Culture.Language>.Fail($"{id} bilgisi null", 400);
            }

            var designFont = await _context.Languages.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (designFont == null)
            {
                return Response<Domain.Entities.Culture.Language>.Fail($"{designFont} bilgisi null", 400);
            }

            return Response<Domain.Entities.Culture.Language>.Success(designFont, 200, 1);
        }

        public async Task<Response<Domain.Entities.Culture.Language>> PostUpdateAsync(PostUpdateLanguage model)
        {
            if (model.LanguageId == null)
            {
                Response<Domain.Entities.Culture.Language>.Fail($"{model.LanguageId} null", 400);

            }
            var language = await _context.Languages.FindAsync(model.LanguageId);
            if (language == null)
            {
                Response<Domain.Entities.Culture.Language>.Fail($"{model.LanguageId}'li bilgiler null", 400);
            }

            language.LangName = model.LangName;
            language.LangCode = model.LangCode;
            language.IsRtl = model.IsRtl;

            await _context.SaveChangesAsync();
            return Response<Domain.Entities.Culture.Language>.Success(language, 200, 1);
        }

     
    }
}
