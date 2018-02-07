using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebMVC.Models;
using WebMVC.Infrastructure;
using System.Linq;

namespace WebMVC.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class AdminController : Controller
    {
        // GET: Admin
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        AppIdentityDbContext db = new AppIdentityDbContext();
        public AdminController()
        {

        }
        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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
        public ActionResult Index()
        {
       
            return View(UserManager.Users);
        }

        public ActionResult Create()
        {
            ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", "");

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RegisterModel model)
        {
            if (ModelState.IsValid)
            {

                var user = new Models.ApplicationUser { UserName = model.UserName,AgentName=model.agentName};
                //传入Password并转换成PasswordHash
                IdentityResult result = await UserManager.CreateAsync(user,
                    model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                AddErrorsFromResult(result);
            }
            ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", "");

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            Models.ApplicationUser user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                if (user.UserName == "Admin")
                {
                    return View("Error", new[] { "请勿删除管理员！" });
                }

                IdentityResult result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                return View("Error", result.Errors);
            }
            return View("Error", new[] { "User Not Found" });
        }

        public async Task<ActionResult> Edit(string id)
        {
          
            Models.ApplicationUser user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", "");

                return View(user);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(string id, string email, string password)
        {
            //根据Id找到AppUser对象
            Models.ApplicationUser user = await UserManager.FindByIdAsync(id);

            if (user != null)
            {
                if (user.UserName == "Admin")
                {
                    return View("Error", new[] { "请勿修改管理员密码！" });
                }

                IdentityResult validPass = null;
                if (password != string.Empty)
                {
                    //验证密码是否满足要求
                    validPass = await UserManager.PasswordValidator.ValidateAsync(password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = UserManager.PasswordHasher.HashPassword(password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }
                ////验证Email是否满足要求
                //user.Email = email;
                //IdentityResult validEmail = await UserManager.UserValidator.ValidateAsync(user);
                //if (!validEmail.Succeeded)
                //{
                //    AddErrorsFromResult(validEmail);
                //}
               // if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded && validPass.Succeeded))

                    if ( validPass == null ||  validPass.Succeeded)
                {
                    IdentityResult result = await UserManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "无法找到改用户");
            }
            ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", "");

            return View(user);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    
 
    }
}
