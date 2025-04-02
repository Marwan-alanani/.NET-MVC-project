namespace C43_G04_MVC03.Presentation.DAL.Models;

public class ApplicationUser : IdentityUser
{
    public string  FistName { get; set; }
    public string LastName { get; set; }
}