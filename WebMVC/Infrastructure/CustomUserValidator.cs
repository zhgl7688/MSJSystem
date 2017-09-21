using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using WebMVC.Models;

namespace WebMVC.Infrastructure
{
    public class CustomUserValidator : UserValidator<Models.ApplicationUser>
    {
        public CustomUserValidator(ApplicationUserManager mgr)
            : base(mgr)
        {
        }

        public override async Task<IdentityResult> ValidateAsync(Models.ApplicationUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);

            if (user.Email!=null&&!user.Email.ToLower().EndsWith("@gmail.com"))
            {
                List<string> errors = result.Errors.ToList();
                errors.Add("Email 地址只支持gmail域名");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}
