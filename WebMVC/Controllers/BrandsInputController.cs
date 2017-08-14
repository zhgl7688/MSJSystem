using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Common;
using WebMVC.Models;
using WebMVC.BLL;

namespace WebMVC.Controllers
{
    public class BrandsInputController : Controller
    {
        // GET: BrandsInput
        MSJDBContext db = new MSJDBContext();
     


        public ActionResult Index()
        {
            var models = db.BrandsInputs.ToList();
            return View(models);
        }

        // GET: BrandsInput/Details/5
        public ActionResult Details(int id)
        {
            var brand = db.BrandsInputs.FirstOrDefault(s => s.BrandID == id);
            return View(brand);
        }

        // GET: BrandsInput/Create
        public ActionResult Create()
        {
            ViewData["stageList"] = GetStageList();
            ViewData["brands"] = GetBrandList();
            return View(new BrandsInput());
        }

        // POST: BrandsInput/Create
        [HttpPost]
        public ActionResult Create(BrandsInput collection)
        {
            try
            {
                var brand = db.BrandsInputs.FirstOrDefault(s => s.Brand == collection.Brand && s.Stage == collection.Stage);
                if (brand != null)
                {
                    return Content("<script>alert('已有" + collection.Brand + collection.Stage + "信息，请重新选择');location='" + Url.Action("Create", "BrandsInput") + "'</script>");
                }
                collection.BrandID = db.BrandsInputs.Select(s => s.BrandID).Max() + 1;
                collection.UserId = ((User)Session["user"]).UserId;
                db.BrandsInputs.Add(collection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }

        // GET: BrandsInput/Edit/5
        public ActionResult Edit(int id)
        {
            var brand = db.BrandsInputs.FirstOrDefault(s => s.BrandID == id);
            ViewData["stageList"] = GetStageList();
            ViewData["brands"] = GetBrandList();
            return View(brand);
        }

        // POST: BrandsInput/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BrandTable collection)
        {
            try
            {
                // TODO: Add update logic here
                var brand = db.BrandsInputs.FirstOrDefault(s => s.BrandID == id);
                var repeatbrand = db.BrandsInputs.FirstOrDefault(s => s.Brand == collection.Brand && s.Stage == collection.Stage && s.BrandID != id);
                if (repeatbrand != null)
                {
                    return Content("<script>alert('已有" + collection.Brand + collection.Stage + "信息，请重新选择');location='" + Url.Action("Edit", "BrandsInput") + "'</script>");
                }
                db.BrandsInputs.Remove(brand);
                collection.UserId = ((User)Session["user"]).UserId;
                db.BrandsInputs.Add(collection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BrandsInput/Delete/5
        public ActionResult Delete(int id)
        {
            var brand = db.BrandsInputs.FirstOrDefault(s => s.BrandID == id);
            db.BrandsInputs.Remove(brand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: BrandsInput/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

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
        public List<SelectListItem> GetBrandList()
        {
            List<SelectListItem> brandList = new List<SelectListItem>();
            foreach (var item in Enum.GetNames(typeof(Brand)))
            {
                brandList.Add(new SelectListItem { Text = item, Value = item });
            }
            return brandList;
        }
    }
}
