using Business.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RFM.Data.Entity.RequestModels;
using RFM.Data.Entity.ResponseModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static RFM.Helper.Enums.Enums;

namespace Recommendation_For_Movie_Service.Controllers
{
    [Produces("application/json")]


    public class AuthController : Controller
    {
        private readonly ILoginService _loginService;

        private readonly IConfiguration _configuration;
        public  AuthController(ILoginService loginService, IConfiguration configuration)
            {
            this._loginService = loginService;

            _configuration = configuration;
        }
        

        
        [HttpPost]
        [Route("api/Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {

            bool loginResults = await _loginService.Logins(model.Username,model.Password);
            if (loginResults )
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

       
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
