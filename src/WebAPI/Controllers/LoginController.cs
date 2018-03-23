using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        private TokenService _tokenService;

        public LoginController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet]
        public string Get()
        {
            var userId = "Jack";
            var roles = new List<string>
            {
                "Admin",
                "SuperUser",
                "SuperStar"
            };

            var claims= _tokenService.CreateJwtClaims(userId, roles);
            var token = _tokenService.CreateToken(claims);

            return token;
        }

    }
}