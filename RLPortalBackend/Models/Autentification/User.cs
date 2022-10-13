using Microsoft.AspNetCore.Identity;

namespace RLPortal.Models.Autentification;

// Add profile data for application users by adding properties to the User class
public class User : IdentityUser
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
}

