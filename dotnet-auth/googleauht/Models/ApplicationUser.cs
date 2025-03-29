// Models/ApplicationUser.cs
using Microsoft.AspNetCore.Identity;

namespace googleauht.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Provider { get; set; } // "Google", "Manual", etc.
        public string? ProviderUserId { get; set; } // Now nullable
    }
}