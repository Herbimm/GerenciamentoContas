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

                if (user != null && !await _userManager.IsLockedOutAsync(user))
                {
                    if (await _userManager.CheckPasswordAsync(user, model.Password))
                    {                    
                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError("", "E-Mail não está valido");
                        return View();
                    }
                     await _userManager.ResetAccessFailedCountAsync(user);
                        if (await _userManager.GetTwoFactorEnabledAsync(user))
                        {
                            var validator = await _userManager.GetValidTwoFactorProvidersAsync(user);
                            if (validator.Contains("Email"))
                            {
                                var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");
                                System.IO.File.WriteAllText("email2sv.txt", token);
                                await HttpContext.SignInAsync(IdentityConstants.TwoFactorUserIdScheme, Store2FA(user.Id, "Email"));
                                return RedirectToAction("TwoFactor");
                            }
                        }

                    var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

                    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, principal);
                    return RedirectToAction("About");
                    }
                    await _userManager.AccessFailedAsync(user);

                    if (await _userManager.IsLockedOutAsync(user))
                    {
                        //Email deve ser enviado com a sugestão de mudança de senha pelo motivo que ela foi bloqueada pelo metodo LockedOut
                    }
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
                    return View("Sucess");
                }
                else
                {
                    // Aqui coloca mensagem falando que o usuario não foi encontrado.
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            return View(new ResetPasswordModel { Token = token, Email = email});
        } 
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (!result.Succeeded)
                    {
                        foreach (var erro in result.Errors)
                        {
                            ModelState.AddModelError("", erro.Description);
                        }
                        return View();
                    }
                    return View("Sucess");
                }
                ModelState.AddModelError("", "Invalid Request");
            }
            return View();
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
                        UserName = model.UserName,
                        Email = model.UserName
                    };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var confirmationEmail = Url.Action("ConfirmEmailAddress", "Home", new { token = token, email = user.Email }, Request.Scheme);
                        System.IO.File.WriteAllText("confirmationEmail.txt", confirmationEmail);
                    }
                    else
                    {
                        foreach (var erro in result.Errors)
                        {
                            ModelState.AddModelError("", erro.Description);
                        }
                        return View();
                    }
                }
                return View("Sucess");
            }
            return View("Sucess");
        }

        public async Task<IActionResult> ConfirmEmailAddress(string token, string email)
        {

            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return View("Sucess");
                }
            }
            return View("Erro");
        }
        [HttpGet]
        public IActionResult TwoFactor()
        {
            return View();
        } 
        [HttpPost]
        public async Task<IActionResult> TwoFactor(TwoFactorModel model)
        {
            var result = await HttpContext.AuthenticateAsync(IdentityConstants.TwoFactorUserIdScheme);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Seu Token Expirou!");
                return View();
            }
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(result.Principal.FindFirstValue("sub"));
                if (user != null)
                {
                    var isValid = await _userManager.VerifyTwoFactorTokenAsync(user, result.Principal.FindFirstValue("arm"), model.Token);
                    if (isValid)
                    {
                        await HttpContext.SignOutAsync(IdentityConstants.TwoFactorUserIdScheme);
                        var claimsPrincipal = await _userClaimsPrincipalFactory.CreateAsync(user);
                        await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, claimsPrincipal);

                        return RedirectToAction("About");
                    }
                    ModelState.AddModelError("", "Invalid Token");
                    return View();
                }
                ModelState.AddModelError("", "Invalid Request");
            }
            return View();
        }

        public ClaimsPrincipal Store2FA(string userId, string provider)
        {
            var identity = new ClaimsIdentity(new List<Claim>
            {
                new Claim("sub", userId),
                new Claim("arm", provider)
            },IdentityConstants.TwoFactorUserIdScheme);

            return new ClaimsPrincipal(identity);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}