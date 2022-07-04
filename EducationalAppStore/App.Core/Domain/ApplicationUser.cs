using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace App.Core.Domain
{
    public class ApplicationUser: IdentityUser
    {
        [PersonalData]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [PersonalData]
        [StringLength(50)]
        public string? LastName { get; set; }    
        [PersonalData]
        public string? Photo { get; set; }
        [StringLength(50)]
        [PersonalData]
        public string? FacebookLink { get; set; }
        [StringLength(50)]
        [PersonalData]
        public string? twitterLink { get; set; }
        [StringLength(50)]
        [PersonalData]
        public string? LinckedinLink { get; set; }
        [StringLength(50)]
        [PersonalData]
        public string? InstgramLink { get; set; }
    }
}
