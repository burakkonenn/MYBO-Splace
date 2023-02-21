using Microsoft.AspNetCore.Mvc;
using SS.WebApi.Configuration;
using Web.Application.Abstractions.Services.SocialMedia;
using Web.Application.Abstractions.Services.Words;
using Web.Application.DTOs.SocialMedia;
using Web.Application.DTOs.Words;

namespace Web.API.Controllers
{
    public class SocialMediaController : BaseController
    {

        private readonly ISocialMediaService _socialMediaService;
        public SocialMediaController(ISocialMediaService soSocialMediaService)
        {
            _socialMediaService = soSocialMediaService;
        }

        [HttpPost]
        [Route("SocialMediaCreate")]
        public async Task<IActionResult> Create(CreateSocialMedia model)
        {
            return CreateActionResultInstance(await _socialMediaService.CreateAsync(model));
        }

        [HttpGet]
        [Route("SocialMediaGetUpdate")]
        public async Task<IActionResult> GetUpdate(Guid? id)
        {
            return CreateActionResultInstance(await _socialMediaService.GetUpdateAsync(id));
        }

        [HttpPost]
        [Route("SocialMediaPostUpdate")]
        public async Task<IActionResult> PostUpdate(PostUpdateSocialMedia model)
        {
            return CreateActionResultInstance(await _socialMediaService.PostUpdateAsync(model));
        }

    }
}
