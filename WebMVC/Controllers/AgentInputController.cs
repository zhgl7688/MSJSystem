using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebMVC.Common;
using WebMVC.Infrastructure;
using WebMVC.Models;


namespace WebMVC.Controllers
{
    public class AgentInputController : Controller
    {
        AppIdentityDbContext db = new AppIdentityDbContext();

        // GET: AgentInput
        //代理

        //[Authorize]
        public ActionResult Index()
        {
            // ClaimsIdentity claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;

            var models = db.AgentInputs.Where(s => s.UserId == User.Identity.Name).ToList();
            
            return View(models);
        }

        // GET: AgentInput/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.AgentInputs.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);

        }

        // GET: AgentInput/Create
        public ActionResult Create1()
        {
            ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value!=0), "Text", "Text", "");
            ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", "");
            AgentInput agentInput = new AgentInput();
            return View(new AgentInput());
        }
        public ActionResult Create()
        {
            ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", "");

            //ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", "");
            ViewBag.Stage = new SelectList(db.StageAdd.Where(s => s.Stage != null), "Stage", "Stage", "");

            //ViewBag.retailPriceRC = db.StageAdd.Where(s => s.Stage != null); 
            var stageAddList = db.StageAdd.Where(s => s.Stage != null).ToList();
            //stageAddList.Add(temp);
            //stageAddList.Add(temp1);
            var model = new AgentInput()
            {
                StageAdds = stageAddList
            };

            return View(model);
        }
        // POST: AgentInput/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgentInput collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    AgentInput agentInput;
                    var userName = User.Identity.GetUserName();
                    if (string.IsNullOrEmpty(userName))
                    {
                        agentInput = db.AgentInputs.FirstOrDefault(s => s.AgentName == collection.AgentName && s.Stage == collection.Stage && s.UserId == "");

                    }
                    else
                    {
                        agentInput = db.AgentInputs.FirstOrDefault(s => s.AgentName == collection.AgentName && s.Stage == collection.Stage && s.UserId == userName);
                    }
                    if (agentInput != null)
                    {
                        ModelState.AddModelError("", "已有" + collection.AgentName + collection.Stage + "信息，请重新选择");
                        ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", "");
                        ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", "");
                        return View(collection);
                    }
                    collection.UserId = User.Identity.Name;
                    db.AgentInputs.Add(collection);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", "");
                    ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", "");

                    return View();
                }
            }
            catch
            {
                ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", "");
                ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", "");

                return View();
            }
        }

        // GET: AgentInput/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var model = db.AgentInputs.Find(id);
            if (model == null) return HttpNotFound();
            ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text",model.Stage);
            ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", model.AgentName);

            return View(model);
        }

        // POST: AgentInput/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude ="UserId")]AgentInput collection)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    AgentInput repeatbrand;
                    var userName = User.Identity.GetUserName();
                    if (string.IsNullOrEmpty(userName))
                    {
                        userName = "";

                    }
                    repeatbrand = db.AgentInputs.FirstOrDefault(
                        s => s.AgentName == collection.AgentName &&
                        s.Stage == collection.Stage &&
                        s.UserId == userName &&
                        s.AgentId != collection.AgentId);


                    if (repeatbrand != null)
                    {
                        ModelState.AddModelError("", "已有" + collection.AgentName + collection.Stage + "信息，请重新选择");
                        ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", "");
                        ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", "");
                        return View(collection);
                    }
                    collection.UserId = User.Identity.Name;
                    db.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                    // collection.UserId = ((User)Session["user"]).UserId;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", collection.Stage);
                    ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", collection.AgentName);

                    return View(collection);
                }


            }
            catch
            {
                return View();
            }
        }

        // GET: AgentInput/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var brand = db.AgentInputs.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }


        // POST: BrandsInput/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var agentInput = db.AgentInputs.Find(id);
                db.AgentInputs.Remove(agentInput);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public List<SelectListItem> GetStageList()
        {
            List<SelectListItem> stageList = new List<SelectListItem>();
            foreach (var item in Enum.GetNames(typeof(Stage)))
            {
                stageList.Add(new SelectListItem { Text = item, Value = item });
            }
            return stageList;
        }
        public List<SelectListItem> GetStageListRemoveOne()
        {
            List<SelectListItem> stageList = new List<SelectListItem>();
            foreach (var item in Enum.GetNames(typeof(Stage)))
            {
                if (item == Stage.起始阶段.ToString()) continue;
                stageList.Add(new SelectListItem { Text = item, Value = item });
            }
            return stageList;
        }
        public List<SelectListItem> GetAgentNameList()
        {
            List<SelectListItem> brandList = new List<SelectListItem>();
            foreach (var item in Enum.GetNames(typeof(AgentName)))
            {
                brandList.Add(new SelectListItem {  Text = item, Value = item });
            }
            return brandList;
        }
    }
}