using BlazorApp.Services;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private RespondentService _service;

        public LoginController(RespondentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RespondentViewModel model)
        {
            var entry = await _service.LoginAsync(model);
            return Ok(entry);
        }
    }
}
