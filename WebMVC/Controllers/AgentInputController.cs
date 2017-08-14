using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Common;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class AgentInputController : Controller
    {
        MSJDBContext db = new MSJDBContext();

        // GET: AgentInput
        public ActionResult Index()
        {
            var models = db.AgentInputs.ToList();
            return View(models);
        }

        // GET: AgentInput/Details/5
        public ActionResult Details(int id)
        {
            var brand = db.AgentInputs.FirstOrDefault(s => s.AgentId == id);
            return View(brand);
        }

        // GET: AgentInput/Create
        public ActionResult Create()
        {
            ViewData["stageList"] = GetStageList();
            ViewData["agentName"] = GetAgentNameList();
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
                var brand = db.AgentInputs.FirstOrDefault(s => s.AgentName == collection.AgentName && s.Stage == collection.Stage);
                if (brand != null)
                {
                    return Content("<script>alert('已有" + collection.AgentName + collection.Stage + "信息，请重新选择');location='" + Url.Action("Create", "BrandsInput") + "'</script>");
                }
                collection.AgentId = db.BrandsInputs.Select(s => s.BrandID).Max() + 1;
                collection.UserId = ((User)Session["user"]).UserId;
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
        public ActionResult Edit(int id)
        {
            var brand = db.AgentInputs.FirstOrDefault(s => s.AgentId == id);
            ViewData["stageList"] = GetStageList();
            ViewData["agentName"] = GetAgentNameList();
            return View(brand);
        }

        // POST: AgentInput/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AgentInput collection)
        {
            try
            {
                // TODO: Add update logic here
                var brand = db.AgentInputs.FirstOrDefault(s => s.AgentId == id);
                var repeatbrand = db.AgentInputs.FirstOrDefault(s => s.AgentName == collection.AgentName && s.Stage == collection.Stage && s.AgentId != id);
                if (repeatbrand != null)
                {
                    return Content("<script>alert('已有" + collection.AgentName + collection.Stage + "信息，请重新选择');location='" + Url.Action("Edit", "BrandsInput") + "'</script>");
                }
                db.AgentInputs.Remove(brand);
                collection.UserId = ((User)Session["user"]).UserId;
                db.AgentInputs.Add(collection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AgentInput/Delete/5
        public ActionResult Delete(int id)
        {
            var brand = db.AgentInputs.FirstOrDefault(s => s.AgentId == id);
            db.AgentInputs.Remove(brand);
            db.SaveChanges();
            return View();
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
