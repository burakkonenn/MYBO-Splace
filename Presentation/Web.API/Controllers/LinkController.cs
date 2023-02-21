using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS.WebApi.Configuration;
using Web.Application.Abstractions.Services.Design;
using Web.Application.Abstractions.Services.Link;
using Web.Application.DTOs.Design.DesignBackground;
using Web.Application.DTOs.Link;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : BaseController
    {
        private readonly ILinkService _linkService;
        public LinkController(ILinkService linkService)
        {
            _linkService= linkService;
        }

        [HttpPost]
        [Route("LinkCreate")]
        public async Task<IActionResult> Create(CreateLink model)
        {
            return CreateActionResultInstance(await _linkService.CreateAsync(model));
        }

        [HttpGet]
        [Route("LinkGetUpdate")]
        public async Task<IActionResult> GetUpdate(Guid? id)
        {
            return CreateActionResultInstance(await _linkService.GetUpdateAsync(id));
        }

        [HttpPost]
        [Route("LinkPostUpdate")]
        public async Task<IActionResult> PostUpdate(PostUpdateLink model)
        {
            return CreateActionResultInstance(await _linkService.PostUpdateAsync(model));
        }
    }
}
