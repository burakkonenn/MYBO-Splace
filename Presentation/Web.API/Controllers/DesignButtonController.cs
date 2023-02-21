using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS.WebApi.Configuration;
using Web.Application.Abstractions.Services.Design;
using Web.Application.DTOs.Design.DesignBackground;
using Web.Application.DTOs.Design.DesignButton;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignButtonController : BaseController
    {

        private readonly IDesignButtonService _designButton;
        public DesignButtonController(IDesignButtonService designButton)
        {
            _designButton= designButton;    
        }


        [HttpPost]
        [Route("DesignButtonCreate")]
        public async Task<IActionResult> Create(CreateDesignButton model)
        {
            return CreateActionResultInstance(await _designButton.CreateAsync(model));
        }

        [HttpGet]
        [Route("DesignButtonGetUpdate")]
        public async Task<IActionResult> GetUpdate(Guid? id)
        {
            return CreateActionResultInstance(await _designButton.GetUpdateAsync(id));
        }

        [HttpPost]
        [Route("DesignButtonUpdate")]
        public async Task<IActionResult> PostUpdate(PostUpdateDesignButton model)
        {
            return CreateActionResultInstance(await _designButton.PostUpdateAsync(model));
        }
    }
}
