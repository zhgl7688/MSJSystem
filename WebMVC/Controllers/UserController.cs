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


namespace WebMVC.Controllers
{
    public class UserController : Controller
    {
        UserService userService = new UserService();
        MSJDBContext db = new MSJDBContext();
        // GET: User

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(s => s.UserName == model.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("UserName", "用户不存在");
                }
                else if (user.Password == model.Password)
                {
                    var _identity = userService.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = model.RememberMe }, _identity);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("Password", "密码不正确");
                }
                return View();
            }


            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            ModelState.AddModelError("", "提供的用户名或密码不正确。");
            return View(model);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        public ActionResult LogOff()
        {

            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // 尝试注册用户
                try
                {
                    if (db.Users.FirstOrDefault(s => s.UserName == model.UserName) != null)
                        ModelState.AddModelError("UserName", "用户名已存在");
                    else
                    {
                        User _user = new Models.User
                        {
                            UserName = model.UserName,
                            Password = model.Password
                        };
                        db.Users.Add(_user);
                        db.SaveChanges();
                        if (_user.UserId > 0)
                        {
                            var _identity = userService.CreateIdentity(_user, DefaultAuthenticationTypes.ApplicationCookie);
                            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                            AuthenticationManager.SignIn(_identity);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "注册失败！");
                         }

                    }
                    //   return RedirectToAction("Index", "Home");
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
        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }
        #endregion
    }
}
