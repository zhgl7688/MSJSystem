using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using WebMVC.IBLL;
using WebMVC.Models;

namespace WebMVC.BLL
{
    public class UserService : InterfaceUserService
    {
        public ClaimsIdentity CreateIdentity(User user, string authenticationType)
        {
            ClaimsIdentity _identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            _identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            _identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()));
            _identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
            //_identity.AddClaim(new Claim("DisplayName", user.UserName));
            return _identity;
        }
    }
}