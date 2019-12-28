using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreAuth.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            var claims = new List<Claim>(){
                new Claim(ClaimTypes.Name,"rud9321"),
                new Claim(ClaimTypes.Email,"rud@mail.com")
            };

            var claimIdentity = new ClaimsIdentity(claims, "rudClaimIdentity");
            var claimPrincipal = new ClaimsPrincipal(new[] { claimIdentity });
            HttpContext.SignInAsync(claimPrincipal);
            return RedirectToAction("Index","Home");
        }
    }
}
