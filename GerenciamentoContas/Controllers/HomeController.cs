using GerenciamentoContas.Domain.Entity.Identy;
using GerenciamentoContas.Models;
using GerenciamentoContas.Models.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace GerenciamentoContas.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<MyUser> _signInManager;
        private readonly IUserClaimsPrincipalFactory<MyUser> _userClaimsPrincipalFactory;
        private readonly UserManager<MyUser> _userManager;

        public HomeController(UserManager<MyUser> userManager,
            IUserClaimsPrincipalFactory<MyUser> userClaimsPrincipalFactory,
            SignInManager<MyUser> signInManager)
        {
            _signInManager = signInManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Authorize]
        public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Sucess()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

                    await HttpContext.SignInAsync("Identity.Application", principal);
                    return RedirectToAction("About");
                }
                ModelState.AddModelError("", "Usuário ou senha incorreto.");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ForgetPassword()
        {
            return View();        
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var resetUrl = Url.Action("ResetPassword", "Home", new {
                        token = token, email = model.Email }, Request.Scheme);
                    System.IO.File.WriteAllText("resetLink.txt", resetUrl);
                }
                else
                {
                    // Aqui coloca mensagem falando que o usuario não foi encontrado.
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ResetPassword()
        {
            return View();
        } 
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {

            }
        }
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    user = new MyUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = model.UserName
                    };
                    var result = await _userManager.CreateAsync(user, model.Password);
                }
                return View("Sucess");
            }
            return View("Sucess");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}