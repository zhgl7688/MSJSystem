using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMVC.BLL;
using WebMVC.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using WebMVC.Infrastructure;

namespace WebMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
          // GET: User

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    return View("Error", new string[] { " 您已经登录！" });
            //}
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /User/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindAsync(model.UserName, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "无效的用户名或密码");
                }
                else
                {
                    var claimsIdentity =
               await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, claimsIdentity);
                    return Redirect(returnUrl??"/home/index");
                }

            }
            //var user = db.Users.FirstOrDefault(s => s.UserName == model.UserName);
            //if (user == null)
            //{
            //    ModelState.AddModelError("UserName", "用户不存在");
            //}
            //else if (user.Password == model.Password)
            //{
            //    var _identity = userService.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            //    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = model.RememberMe }, _identity);
            //    return RedirectToLocal(returnUrl);
            //}
            //else
            //{
            //    ModelState.AddModelError("Password", "密码不正确");
            //}
            // return View();
            // }
            ViewBag.returnUrl = returnUrl;
   
            return View(model);
        }

        //
        // POST: /User/LogOff


        public ActionResult LogOff()
        {

            AuthManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /User/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /User/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // 尝试注册用户
                try
                {
                    var user = new AppUser { UserName = model.UserName };
                    IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    AddErrorsFromResult(result);
                    //if (db.Users.FirstOrDefault(s => s.UserName == model.UserName) != null)
                    //    ModelState.AddModelError("UserName", "用户名已存在");
                    //else
                    //{
                    //    User _user = new Models.User
                    //    {
                    //        UserName = model.UserName,
                    //        Password = model.Password
                    //    };
                    //    db.Users.Add(_user);
                    //    db.SaveChanges();
                    //    if (_user.UserId > 0)
                    //    {
                    //        var _identity = userService.CreateIdentity(_user, DefaultAuthenticationTypes.ApplicationCookie);
                    //        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    //        AuthenticationManager.SignIn(_identity);
                    //        return RedirectToAction("Index", "Home");
                    //    }
                    //    else
                    //    {
                    //        ModelState.AddModelError("", "注册失败！");
                    //     }

                    //}
                    ////   return RedirectToAction("Index", "Home");
                 return View(model);

                }
                catch (MembershipCreateUserException e)
                {
                   // ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }









        #region 帮助程序

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        #endregion
        #region 属性
         private IAuthenticationManager AuthManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
        private AppUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); }
        }

        #endregion
    }
}
