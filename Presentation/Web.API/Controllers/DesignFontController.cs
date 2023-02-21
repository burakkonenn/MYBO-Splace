using Microsoft.AspNetCore.Mvc;
using SS.WebApi.Configuration;
using Web.Application.Abstractions.Services.Design;
using Web.Application.DTOs.Design.DesignBackground;
using Web.Application.DTOs.Design.DesignFont;

namespace Web.API.Controllers
{
    public class DesignFontController : BaseController
    {
        private readonly IDesignFontService _designFont;
        public DesignFontController(IDesignFontService designFont)
        {
            _designFont= designFont;
        }

        [HttpPost]
        [Route("DesignFontCreate")]
        public async Task<IActionResult> Create(CreateDesignFont model)
        {
            return CreateActionResultInstance(await _designFont.CreateAsync(model));
        }

        [HttpGet]
        [Route("DesignFontGet")]
        public async Task<IActionResult> GetUpdate(Guid? id)
        {
            return CreateActionResultInstance(await _designFont.GetUpdateAsync(id));
        }

        [HttpPost]
        [Route("DesignFontPostUpdate")]
        public async Task<IActionResult> PostUpdate(PostUpdateDesignFont model)
        {
            return CreateActionResultInstance(await _designFont.PostUpdateAsync(model));
        }
    }
}
