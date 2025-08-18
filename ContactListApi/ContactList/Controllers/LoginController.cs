using ContactList.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            return Ok();
        }

    }
}
