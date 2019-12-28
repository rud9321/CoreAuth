using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreAuth.Web.Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<IdentityUser> _identityManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(ILogger<AccountController> logger,
            UserManager<IdentityUser> identityManager,
            SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _identityManager = identityManager;
            _signInManager = signInManager;
        }
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _identityManager.FindByNameAsync(username);
            if (user != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Privacy","Home");
                }
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(string username, string password)
        {
            _logger.LogTrace($"provided username {username} and password is {password}");
            var user = new IdentityUser(){
                UserName = username,
                Email = $"{username}@emai.com"
            };
            _logger.LogInformation($"current identity user is {user}");
            var result = await _identityManager.CreateAsync(user,password);
            _logger.LogTrace($"register status is :{result}");
            if (result.Succeeded)
            {
                //do signin
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Privacy", "Home");
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
