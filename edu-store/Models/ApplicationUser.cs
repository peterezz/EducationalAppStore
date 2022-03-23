using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace edu_store.Models
{
    public class ApplicationUser :IdentityUser
    {
        [Required,MaxLength(100)]
        public string FristName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
    }
}
