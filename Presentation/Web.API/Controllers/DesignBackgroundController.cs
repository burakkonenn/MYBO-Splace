using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS.WebApi.Configuration;
using Web.Application.Abstractions.Services.Design;
using Web.Application.Abstractions.Services.User;
using Web.Application.DTOs.Design.DesignBackground;
using Web.Application.DTOs.User;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignBackgroundController : BaseController
    {
        private readonly IDesignBackgroundService _designBackground;
        public DesignBackgroundController(IDesignBackgroundService designBackground)
        {
            _designBackground = designBackground;
        }

        [HttpPost]
        [Route("DesignBackgroundCreate")]
        public async Task<IActionResult> Create(CreateDesignBackground model)
        {
            return CreateActionResultInstance(await _designBackground.CreateAsync(model));
        }

        [HttpGet]
        [Route("DesignBackgroundGetUpdate")]
        public async Task<IActionResult> GetUpdate(Guid? id)
        {
            return CreateActionResultInstance(await _designBackground.GetUpdateAsync(id));
        }

        [HttpPost]
        [Route("DesignBackgroundPostUpdate")]
        public async Task<IActionResult> PostUpdate(PostUpdateDesignBackground model)
        {
            return CreateActionResultInstance(await _designBackground.PostUpdateAsync(model));
        }
    }
}
