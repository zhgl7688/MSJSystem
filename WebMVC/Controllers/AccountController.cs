using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WebMVC.Infrastructure;
using WebMVC.Models;


namespace WebMVC.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {  
        // GET: Account
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
  
        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        public ActionResult LogOut()
        {
            HttpContext httpContext = System.Web.HttpContext.Current;
            AuthManager.SignOut();
            Hashtable hOnline = (Hashtable)httpContext.Application["Online"];
            if (hOnline != null)
            {
                if (hOnline[User.Identity.Name.ToLower()] != null)
                {
                    hOnline.Remove(User.Identity.Name.ToLower());
                    httpContext.Application.Lock();
                    httpContext.Application["Online"] = hOnline;
                    httpContext.Application.UnLock();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [LoginActionFilter]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
                switch (result)
                {
                    case SignInStatus.Success:
                        GetOnline(model.UserName);
                        return RedirectToLocal(returnUrl);
                    case SignInStatus.LockedOut:
                        return View("Lockout");
                    case SignInStatus.RequiresVerification:
                        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                    case SignInStatus.Failure:
                    default:
                        ModelState.AddModelError("", "无效的登录尝试。");
                        return View(model);
                }
                //AppUser user = await UserManager.FindAsync(model.UserName, model.Password);
                //if (user == null)
                //{
                //    ModelState.AddModelError("", "无效的用户名或密码");
                //}
                //else
                //{
                //    var claimsIdentity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                //    claimsIdentity.AddClaims(LocationClaimsProvider.GetClaims(claimsIdentity));
                //    claimsIdentity.AddClaims(ClaimsRoles.CreateRolesFromClaims(claimsIdentity));
                //    AuthManager.SignOut();
                //    AuthManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, claimsIdentity);

                //    return Redirect(returnUrl??"/home/index");
                //}
            }
            ViewBag.returnUrl = returnUrl;

            return View(model);
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Models.ApplicationUser { UserName = model.UserName };
                //传入Password并转换成PasswordHash
                IdentityResult result = await UserManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    var claimsIdentity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    claimsIdentity.AddClaims(LocationClaimsProvider.GetClaims(claimsIdentity));
                    claimsIdentity.AddClaims(ClaimsRoles.CreateRolesFromClaims(claimsIdentity));
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, claimsIdentity);

                    return RedirectToAction("Index","Home");
                }
                AddErrorsFromResult(result);
            }
            return View(model);
        }
        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }
        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }
        [AllowAnonymous]
        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "你的密码已更改。"
                : message == ManageMessageId.SetPasswordSuccess ? "已设置你的密码。"
                : message == ManageMessageId.RemoveLoginSuccess ? "已删除外部登录名。"
                : message == ManageMessageId.Error ? "出现错误。"
                : "";
            ViewBag.HasLocalPassword = HasPassword();
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }
        private IAuthenticationManager AuthManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        /// <summary>
        /// 限制一个用户只能登陆一次
        /// </summary>
        /// <returns></returns>
        private void GetOnline(string userID)
        {
            HttpContext httpContext = System.Web.HttpContext.Current;
            var userOnline =(Hashtable)httpContext.Application["Online"];
            if (userOnline != null)
            {
                IDictionaryEnumerator enumerator = userOnline.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (enumerator.Value != null && enumerator.Value.ToString().Equals(userID.ToString()))
                    {
                        userOnline[enumerator.Key.ToString()] = "_offline_";
                        break;
                    }
                }
            }
            else
            {
                userOnline = new Hashtable();
            }
            userOnline[userID.ToLower()] =Session.SessionID;
            httpContext.Application.Lock();
            httpContext.Application["Online"] = userOnline;
            httpContext.Application.UnLock();

        }
    }
}