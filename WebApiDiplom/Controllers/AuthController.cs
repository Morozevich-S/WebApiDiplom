using Microsoft.AspNetCore.Mvc;
using WebApiDiplom.Services;

namespace WebApiDiplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenservice;

        public AuthController(TokenService tokenservice)
        {
            _tokenservice = tokenservice;
        }

        [HttpPost("signin/{username}")]
        public ActionResult<string> SignIn(string username)
        {
            return _tokenservice.CreateToken(username);
        }
    }
}
