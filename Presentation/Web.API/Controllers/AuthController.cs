using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SS.WebApi.Configuration;
using Web.Application.Abstractions.Services.User;
using Web.Application.DTOs.User;
using Web.Domain.Entities.Identity;

namespace Web.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {

        private readonly IUserService _userServices;

        public AuthController(IUserService userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(CreateUser model) {

            return CreateActionResultInstance(await _userServices.CreateAsync(model));

        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost]
        [Route("ResetPassword")]
        public IActionResult ResetPassword()
        {
            return Ok();
        }


        [HttpPost]
        [Route("ChangePassword")]
        public IActionResult ChangePassword()
        {
            return Ok();
        }
    }
}
