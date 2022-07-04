// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using App.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.UI.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

    
        public string Username { get; set; }
        [BindProperty]


        [TempData]
        public string StatusMessage { get; set; }


        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {



            [Display(Name ="First Name")]
            [StringLength(50,ErrorMessage ="max character length is 50 characters")]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            [StringLength(50, ErrorMessage = "max character length is 50 characters")]
            public string LastName { get; set; }

            public string Username { get; set; }

            [Display(Name = "Profile Picture")]
            public IFormFile ProfilePicture{ get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName=user.FirstName,
                LastName=user.LastName
                
                
                
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            
            if (Input.PhoneNumber != user.PhoneNumber ||
                Input.FirstName != user.FirstName ||
                Input.LastName != user.LastName 
                )
            {
                user.PhoneNumber = Input.PhoneNumber;
                user.FirstName=Input.FirstName;
                user.LastName =Input.LastName;
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    StatusMessage = "Unexpected error when updating your data.";
                    return RedirectToPage();
                }

            }

            if(Input.ProfilePicture != null)
            {
                string photopath = Directory.GetCurrentDirectory() + "/wwwroot/images/team/";
                string photoname = Path.GetFileName(Input.ProfilePicture.FileName);
                string finalpath = photopath + photoname;
                using (var stream = System.IO.File.Create(finalpath))
                {
                    await Input.ProfilePicture.CopyToAsync(stream);
                }
                user.Photo = photoname;
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    StatusMessage = "Unexpected error when updating your data.";
                    return RedirectToPage();
                }
            }
         



            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
