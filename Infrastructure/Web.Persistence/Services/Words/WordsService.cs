using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Abstractions.Services.Words;
using Web.Application.DTOs.Words;
using Web.Domain.Entities.Culture;
using Web.Persistence.Contexts;
using Web.Shared;

namespace Web.Persistence.Services.Words
{
    public class WordsService : IWordsService
    {

        private readonly SplaceDbContext _context;
        public WordsService(SplaceDbContext context)
        {
            _context = context;
        }

        public async Task<Response<Word>> CreateAsync(CreateWord model)
        {
            var words = new Word()
            {
                WordKey = model.WordKey,
                WordValue = model.WordValue,
                LanguageId = model.LanguageId
            };

            await _context.Words.AddAsync(words);
            await _context.SaveChangesAsync();

            return Response<Word>.Success(words, 200, 1);
        }

        public async Task<Response<Word>> GetUpdateAsync(Guid? id)
        {
            if(id == null)
            {
                return Response<Word>.Fail($"{id} bilgisi null", 400);
            }

            var word = await _context.Words.FindAsync(id);
            if(word == null)
            {
                return Response<Word>.Fail($"{word} bilgisi null", 400);
            }

            return Response<Word>.Success(word, 200, 1);
        }

        public async Task<Response<Word>> PostUpdateAsync(PostUpdateWord model)
        {
            if(model.WordId == null)
            {
                return Response<Word>.Fail($"{model.WordId} bilgisi null", 400);
            }

            var word = await _context.Words.FindAsync(model.WordId);

            if (word == null)
            {
                return Response<Word>.Fail($"{word} bilgisi null", 400);
            }

            word.WordValue = model.WordValue;
            word.WordKey = model.WordKey;
            word.LanguageId = model.LanguageId;
            await _context.SaveChangesAsync();
            return Response<Word>.Success(word, 200, 1);
        }
    }
}
