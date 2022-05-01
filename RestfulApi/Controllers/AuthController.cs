using Microsoft.AspNetCore.Mvc;
using RestfulApi.Business.Interfaces;
using RestfulApi.Models.Data.VO;

namespace RestfulApi.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("[controller]/v{version:apiVersion}")]
    public class AuthController : ControllerBase
    {
        private readonly ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            this._loginBusiness = loginBusiness;
        }

        [HttpPost("signin")]
        public IActionResult Signin([FromBody] UserVO user)
        {
            var token = _loginBusiness.ValidateCredentials(user);

            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [HttpPost("refresh")]
        public IActionResult RefreshToken([FromBody] TokenVO tokenVO)
        {
            if (tokenVO == null)
            {
                return BadRequest("Invalid client request");
            }

            var token = _loginBusiness.ValidateCredentials(tokenVO);

            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
