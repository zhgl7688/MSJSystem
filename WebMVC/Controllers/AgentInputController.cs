using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebMVC.Common;
using WebMVC.Infrastructure;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class AgentInputController : Controller
    {
        AppIdentityDbContext db = new AppIdentityDbContext();

        // GET: AgentInput

       //[Authorize]
        public ActionResult Index()
        {
            // ClaimsIdentity claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
         
            var models = db.AgentInputs.Where(s=>s.UserId==User.Identity.Name).ToList();
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
        public ActionResult Create()
        {
            ViewData["stageList"] = GetStageList();
            ViewData["agentName"] = GetAgentNameList();
            AgentInput agentInput =  new AgentInput();
            return View(new AgentInput());
        }

        // POST: AgentInput/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgentInput collection)
        {
            try
            {
                // TODO: Add insert logic here
                var agentInput = db.AgentInputs.FirstOrDefault(s => s.AgentName == collection.AgentName && s.Stage == collection.Stage);
                if (agentInput != null)
                {
                    ModelState.AddModelError("", "已有" + collection.AgentName + collection.Stage + "信息，请重新选择");
                    ViewData["stageList"] = GetStageList();
                    ViewData["agentName"] = GetAgentNameList();
                    return View(collection);
                  }
                collection.UserId = User.Identity.Name;
                db.AgentInputs.Add(collection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AgentInput/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var model = db.AgentInputs.Find(id);
            if (model == null) return HttpNotFound();
            ViewData["stageList"] = GetStageList();
            ViewData["agentNames"] = GetAgentNameList();
            return View(model);
   }

        // POST: AgentInput/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(  AgentInput collection)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var repeatbrand = db.AgentInputs.FirstOrDefault(s => s.AgentName == collection.AgentName && s.Stage == collection.Stage && s.AgentId != collection.AgentId);
                    if (repeatbrand != null)
                    {
                        ModelState.AddModelError("", "已有" + collection.AgentName + collection.Stage + "信息，请重新选择");
                        ViewData["stageList"] = GetStageList();
                        ViewData["agentName"] = GetAgentNameList();
                        return View(collection);
                    }
                    db.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                    // collection.UserId = ((User)Session["user"]).UserId;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["stageList"] = GetStageList();
                    ViewData["agentName"] = GetAgentNameList();
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
        public List<SelectListItem> GetAgentNameList()
        {
            List<SelectListItem> brandList = new List<SelectListItem>();
            foreach (var item in Enum.GetNames(typeof(AgentName)))
            {
                brandList.Add(new SelectListItem { Text = item, Value = item });
            }
            return brandList;
        }
    }
}