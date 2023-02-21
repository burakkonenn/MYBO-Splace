using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS.WebApi.Configuration;
using Web.Application.Abstractions.Services.Design;
using Web.Application.Abstractions.Services.Words;
using Web.Application.DTOs.Design.DesignBackground;
using Web.Application.DTOs.Words;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : BaseController
    {
        private readonly IWordsService _wordService;
        public WordController(IWordsService wordService)
        {
            _wordService = wordService;
        }

        [HttpPost]
        [Route("WordCreate")]
        public async Task<IActionResult> Create(CreateWord model)
        {
            return CreateActionResultInstance(await _wordService.CreateAsync(model));
        }

        [HttpGet]
        [Route("WordGetUpdate")]
        public async Task<IActionResult> GetUpdate(Guid? id)
        {
            return CreateActionResultInstance(await _wordService.GetUpdateAsync(id));
        }

        [HttpPost]
        [Route("WordPostUpdate")]
        public async Task<IActionResult> PostUpdate(PostUpdateWord model)
        {
            return CreateActionResultInstance(await _wordService.PostUpdateAsync(model));
        }
    }
}
