using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Infrastructure;

namespace WebMVC.Controllers
{
    public class CodeInitController : Controller
    {
        private AppIdentityDbContext db = new AppIdentityDbContext();
        // GET: CodeInit
        public ActionResult Index()
        {
            return View();
        }
        //增加阶段
        public ActionResult StageAdd()
        {
            int value = db.CodeInit.Where(s => s.Code == "Stage").Max(s => s.Value) + 1;

            db.CodeInit.Add(new Models.CodeInit
            {
                Code = "Stage",
                 Value=value,
                  Text=$"第{value}阶段",
                CreateDate = DateTime.Now
            });
            db.SaveChanges();
          return  RedirectToAction("Index", "Home");
            
        }
        //增加代理商
       public ActionResult AgentNameAdd()
        {
            int value = db.CodeInit.Where(s=>s.Code== "Agent") .Max(s => s.Value) + 1;

            db.CodeInit.Add(new Models.CodeInit
            {
                Code = "Agent",
                Value = value,
                Text = $"代{value}",
                CreateDate = DateTime.Now
            });
            db.SaveChanges();
         return   RedirectToAction("Index", "Home");
           
        }
    }
}