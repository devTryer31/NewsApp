using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News.Identity.Models;
using System.Linq;
using System.Threading.Tasks;

namespace News.Identity.Areas.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IIdentityServerInteractionService _interactionService;

        public AuthController(UserManager<User> userManager,
            SignInManager<User> signInManager, IIdentityServerInteractionService interactionService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interactionService = interactionService;
        }

        [Route("/")]
        [HttpGet, AllowAnonymous]
        public IActionResult Index()
        {
            return View(_userManager.Users.Count());
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            LoginViewModel vm = new()
            {
                ReturnURL = returnUrl
            };

            return View(vm);
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var user = await _userManager.FindByNameAsync(vm.Username);

            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "Invalid username");
                return View(vm);
            }

            var res = await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, vm.IsRememberMe, false);
            if (res.Succeeded)
                return LocalRedirect(vm.ReturnURL ?? "/");

            ModelState.AddModelError(string.Empty, "Sign in unsucceded");

            return View(vm);
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Register(string returnUrl)
        {
            RegisterViewModel vm = new()
            {
                ReturnURL = returnUrl
            };

            return View(vm);
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            User user = new()
            {
                UserName = vm.Username
            };
            var res = await _userManager.CreateAsync(user, vm.Password);
            if (res.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
                return LocalRedirect(vm.ReturnURL ?? "/");
            }

            ModelState.AddModelError(string.Empty, "Uncsucceded user registration<\\br>Errors:<\\br>"
                + string.Join("\\br", res.Errors.Select(err => err.Description)));

            return View(vm);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await _signInManager.SignOutAsync();
            var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutId);
            return LocalRedirect(logoutRequest.PostLogoutRedirectUri ?? "/");
        }
    }
}
