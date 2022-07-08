using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using App.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace App.UI.Areas.Identity.Pages.Account.Manage
{
    public class ChangeContactInfoModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManger;
        [BindProperty]
        public Data Input { get; set; }
        public ChangeContactInfoModel(UserManager<ApplicationUser> userManger)
        {
            this.userManger = userManger;
        }

        public class Data
        {
            [StringLength(50, ErrorMessage = "max Length is 50 characters")]
            [Display(Name ="Facebook")]
            public string? FacebookLink { get; set; }

            [StringLength(50, ErrorMessage = "max Length is 50 characters")]
            [Display(Name = "Linkedin")]
            public string? LinkedinLink { get; set; }

            [StringLength(50,ErrorMessage ="max Length is 50 characters")]
            [Display(Name = "Twitter")]
            public string? TwitterLink { get; set; }

            [StringLength(50, ErrorMessage = "max Length is 50 characters")]
            [Display(Name = "Instagram")]
            public string? InstgramLink { get; set; }
        }
        private async Task GetUserInfo()
        {
            var user = await userManger.GetUserAsync(User);
            if (user != null)
            {
             new Data()
                {
                    FacebookLink = user.FacebookLink,
                    LinkedinLink = user.LinckedinLink,
                    InstgramLink = user.InstgramLink,
                    TwitterLink = user.twitterLink
                };
            }

            

        }
    
        
        public async Task OnGet()
        {
            await GetUserInfo();
        }
        public async Task OnPost()
        {
            var uesr =await userManger.GetUserAsync(User);
            if(Input.FacebookLink != uesr.FacebookLink ||
                Input.InstgramLink != uesr.InstgramLink ||
                Input.LinkedinLink != uesr.LinckedinLink ||
                Input.TwitterLink != uesr.twitterLink 


                )
            {
                uesr.FacebookLink=Input.FacebookLink;
                uesr.InstgramLink=Input.InstgramLink;
                uesr.LinckedinLink=Input.LinkedinLink;
                uesr.twitterLink=Input.TwitterLink;

               await userManger.UpdateAsync(uesr);
            }

        }
    }
}
