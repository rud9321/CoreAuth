using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreAuth.API.Controllers
{
    [Route("/api/[controller]")]
    public class SecurityController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("token")]
        public IActionResult Token()
        {
            string secureKey = $"Hey-this-is-so-secure-key";

            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey));
            var signingKey = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                    issuer: "someone",
                    audience: "readers",
                    expires: DateTime.Now.AddMinutes(2),
                    signingCredentials: signingKey
                );
            string mostSecureKey = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(mostSecureKey);
        }
    }
}
