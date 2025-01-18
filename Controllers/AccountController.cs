using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace HealthTrack.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login(string returnUrl = "/")
    {
        if (User.Identity?.IsAuthenticated ?? false)
        {
            return Redirect(returnUrl); // Se o usuário já estiver autenticado, redirecione
        }

        ViewData["Title"] = "Login";
        ViewBag.ReturnUrl = returnUrl; // Armazena o URL de retorno para redirecionar após o login
        return View();
    }

    [HttpPost]
    public IActionResult Login(string usuario, string senha, string returnUrl = "/")
    {
        if (usuario == "admin" && senha == "admin123")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return Redirect(returnUrl);
        }

        ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos.");
        return View();
    }

    [HttpPost]
    public IActionResult Logout()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }
}

