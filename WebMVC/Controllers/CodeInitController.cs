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
            var stage = db.CodeInit.ToList();
            SelectList stageList = new SelectList(stage.Where(s => s.Code == "Stage").Select(s => new { s.Text, s.Value }), "Text", "Text", "");
            SelectList agentList = new SelectList(stage.Where(s => s.Code == "Agent").Select(s => new { s.Text, s.Value }), "Text", "Text", "");
            SelectList brandList = new SelectList(stage.Where(s => s.Code == "Brand").Select(s => new { s.Text, s.Value }), "Text", "Text", "");


            ViewBag.stageList = stageList;
            ViewBag.agentList = agentList;
            ViewBag.brandList = brandList;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult index(string stage, string brand, string agent, string text,string Value)
        {
            var create = "创建";
            if (!string.IsNullOrWhiteSpace(stage))
            {
                if (stage == create) StageAdd();
                else StageDel();
            }
            else if (!string.IsNullOrWhiteSpace(brand))
            {
                if (brand == create) brandAdd(Value);
                else brandDel(text);
            }
            else if (!string.IsNullOrWhiteSpace(agent))
            {
                if (agent == create) AgentNameAdd();
                else AgentNameDel();
            }

            return RedirectToAction("index");
        }
        //品牌商增加
        public void brandAdd(string Value)
        {
            int value = db.CodeInit.Where(s => s.Code == "Brand").Max(s => s.Value) + 1;

            db.CodeInit.Add(new Models.CodeInit
            {
                Code = "Brand",
                Value = value,
                Text = Value,
                CreateDate = DateTime.Now
            });
            db.SaveChanges();
        }
        public void brandDel(string Text)
        {
            var brand = db.CodeInit.FirstOrDefault(s => s.Text == Text);
            db.CodeInit.Remove(brand);
            db.SaveChanges();
        }
        //品牌商删除
        //增加阶段
        public void StageAdd()
        {
            var value = 0;
            if (db.CodeInit.Any(s => s.Code == "Stage"))
            {
                value = db.CodeInit.Where(s => s.Code == "Stage").Max(s => s.Value) + 1;
            }

 

            db.CodeInit.Add(new Models.CodeInit
            {
                Code = "Stage",
                Value = value,
                Text = $"第{value}阶段",
                CreateDate = DateTime.Now
            });
            db.SaveChanges();

        }
        //删除阶段
        public void StageDel()
        {

            var agentMax = db.CodeInit.Where(s => s.Code == "Stage").OrderByDescending(s => s.Value).Take(1);
            foreach (var item in agentMax)
            {
                db.CodeInit.Remove(item);
            }
            db.SaveChanges();


        }
        //增加代理商
        public void AgentNameAdd()
        {
            var value = 1;
            if (db.CodeInit.Any(s => s.Code == "Agent"))
            {
                value = db.CodeInit.Where(s => s.Code == "Agent").Max(s => s.Value) + 1;
            }




            db.CodeInit.Add(new Models.CodeInit
            {
                Code = "Agent",
                Value = value,
                Text = $"代{value}",
                CreateDate = DateTime.Now
            });
            db.SaveChanges();


        }
        //删除代理商
        public void AgentNameDel()
        {
            var agentMax = db.CodeInit.Where(s => s.Code == "Agent").OrderByDescending(s => s.Value).Take(1);
            foreach (var item in agentMax)
            {
                db.CodeInit.Remove(item);
            }
            db.SaveChanges();

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