using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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
          //  int value = db.CodeInit.Where(s => s.Code == "Stage").Max(s => s.Value) + 1;

          //  db.CodeInit.Add(new Models.CodeInit
          //  {
          //      Code = "Stage",
          //       Value=value,
          //        Text=$"第{value}阶段",
          //      CreateDate = DateTime.Now
          //  });
          //  db.SaveChanges();
          //return  RedirectToAction("Index", "Home");
            return View(); 
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

        //显示阶段
        public ActionResult StageShow()
        {
            var StageList = db.StageAdd.OrderBy(s => s.Stage).ToList();
            return Json(StageList, JsonRequestBehavior.AllowGet);
        }

        //保存修改阶段
        public ActionResult StageHandle()
        {
            var sr = new StreamReader(Request.InputStream);
            var stream = sr.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var StageList = js.Deserialize<List<Models.StageAdd>>(stream).FirstOrDefault();
            int hasId = db.StageAdd.Where(s => s.Id.Equals(StageList.Id)).Count();
            var Max = db.StageAdd.Count() > 0 ? db.StageAdd.Max(s => s.Id) + 1 : 1;
            if (hasId == 0)
            {
                db.StageAdd.Add(
                    new Models.StageAdd
                    {
                        Id = Max,

                        Stage = StageList.Stage,
                        retail = StageList.retail,
                        retailPrice = StageList.retailPrice
                    });
            }
            else
            {
                var StageObj = db.StageAdd.Where(s => s.Id == StageList.Id).ToList().FirstOrDefault();

                StageObj.Stage = StageList.Stage;
                StageObj.retail = StageList.retail;
                StageObj.retailPrice = StageList.retailPrice;

            }
            db.SaveChanges();
            return RedirectToAction("Index", "home");
        }

        //删除阶段
        public ActionResult StageDelete(int trsId)
        {
            var findId = db.StageAdd.FirstOrDefault(s => s.Id == trsId);
            db.StageAdd.Remove(findId);
            db.SaveChanges();
            return Content("xx");




        }

         
    }
}