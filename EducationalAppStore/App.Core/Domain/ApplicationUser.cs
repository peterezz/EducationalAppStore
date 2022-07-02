using Microsoft.AspNetCore.Identity;
using System;

namespace App.Core.Domain
{
    public class ApplicationUser: IdentityUser
    {
        [PersonalData]
        
        public string? FirstName { get; set; }
        [PersonalData]
        public string? LastName { get; set; }    
        [PersonalData]

        public string? Photo { get; set; }
    }
}
