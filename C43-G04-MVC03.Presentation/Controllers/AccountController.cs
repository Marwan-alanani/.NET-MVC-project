using C43_G04_MVC03.Presentation.DAL.Models;
using C43_G04_MVC03.Presentation.Models;
using Microsoft.AspNetCore.Identity;

namespace C43_G04_MVC03.Presentation.Controllers;

public class AccountController(UserManager<ApplicationUser> userManager) : Controller
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        // 1. Server Side Validation
        if (!ModelState.IsValid) return View(model);

        // Manual Mapping
        var user = new ApplicationUser()
        {
            UserName = model.Email,
            Email = model.Email,
            FistName = model.FirstName,
            LastName = model.LastName,
        };
        var result = _userManager.CreateAsync(user, model.Password).Result;
        if (result.Succeeded) return RedirectToAction(nameof(Login));
        
        foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);
        
        return View(model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
}
/* Security
 *
 * Authentication
 * Who are You?
 * Authorization
 * What are you allowed to do ?
 * Role Based
 * Claims
 * Policy
 *
 * User => [ Username , Email, ..... ]
 *
 * Use Microsoft.AspNetCore.Identity.EntityFrameworkCore
 */