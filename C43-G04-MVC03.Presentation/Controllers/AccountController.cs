namespace C43_G04_MVC03.Presentation.Controllers;

public class AccountController : Controller
{
    public IActionResult Register()
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
