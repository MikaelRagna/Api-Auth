using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_Auth.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class testController : ControllerBase
    {
        [HttpGet]
        public Task<IActionResult> Get()
        {
            return Task.FromResult<IActionResult>(Ok("Hello World!"));
        }
    }
}
