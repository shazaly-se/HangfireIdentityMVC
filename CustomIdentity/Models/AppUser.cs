using Microsoft.AspNetCore.Identity;

namespace CustomIdentity.Models
{
    public class AppUser :IdentityUser
    {
        public string? FullName { get; set; }
    }
}
