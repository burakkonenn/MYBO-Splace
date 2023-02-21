using Microsoft.AspNetCore.Mvc;
using Web.Shared;

namespace SS.WebApi.Configuration
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController : Controller
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
        public IActionResult CreateActionResultJson<T>(Response<T> response)
        {
            return new JsonResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
