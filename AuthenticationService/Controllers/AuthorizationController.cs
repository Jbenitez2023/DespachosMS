using AuthenticationService.Models;
using AuthenticationService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserService _userService;

        public AuthorizationController(ITokenGenerator tokenGenerator, IUserService userService)
        {
            _tokenGenerator = tokenGenerator;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserData request)
        {
           var res = await _userService.validateUser(request);
            if (res.Value == null)
                return NotFound();

            var token = await _tokenGenerator.GenerateToken(request.userName);
            return Ok(token);
        }
    }
}
