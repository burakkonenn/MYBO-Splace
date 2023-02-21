using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS.WebApi.Configuration;
using Web.Application.Abstractions.Services.Design;
using Web.Application.Abstractions.Services.Language;
using Web.Application.DTOs.Design.DesignBackground;
using Web.Application.DTOs.Language;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : BaseController
    {
        private readonly ILanguageService _language;
        public LanguageController(ILanguageService language)
        {
            _language= language;
        }

        [HttpPost]
        [Route("LanguageCreate")]
        public async Task<IActionResult> Create(CreateLanguage model)
        {
            return CreateActionResultInstance(await _language.CreateAsync(model));
        }

        [HttpGet]
        [Route("LanguageGetUpdate")]
        public async Task<IActionResult> GetUpdate(Guid? id)
        {
            return CreateActionResultInstance(await _language.GetUpdateAsync(id));
        }

        [HttpPost]
        [Route("LanguagePostUpdate")]
        public async Task<IActionResult> PostUpdate(PostUpdateLanguage model)
        {
            return CreateActionResultInstance(await _language.PostUpdateAsync(model));
        }
    }
}
