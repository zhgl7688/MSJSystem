using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Common;
using WebMVC.Models;
using WebMVC.BLL;
using System.Net;
using WebMVC.Infrastructure;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace WebMVC.Controllers
{
   // [Authorize(Roles = "品牌商")]
    public class BrandsInputController : Controller
    {
        // GET: BrandsInput
        AppIdentityDbContext db = new AppIdentityDbContext();

        public ActionResult Index()
        {
            List<BrandsInput> models;
            if (string.IsNullOrEmpty(User.Identity.GetUserName()))
            {
                models = db.BrandsInputs.Where(s => s.UserId == "").ToList();

                return View(models);
            }
            if (User.IsInRole("品牌商"))
            {
                models = db.BrandsInputs.Where(s => s.UserId == "admin").ToList();
                //  var  models= db.BrandsInputs.ToList();
                return View(models);
            }
            return Content("<script>alert('没有权限');location='" + Url.Action("index", "home") + "'</script>");
        
        }

        // GET: BrandsInput/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var brand = db.BrandsInputs.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // GET: BrandsInput/Create
        public ActionResult Create()
        {
            ViewData["stageList"] = GetStageList();
            ViewData["brands"] = GetBrandList();
            var model = new BrandsInput();
            return View(model);
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
                    ModelState.AddModelError("", "已有" + collection.Brand + collection.Stage + "信息，请重新选择");
                    ViewData["stageList"] = GetStageList();
                    ViewData["brands"] = GetBrandList();
                    return View(collection);
                }

                collection.UserId = User.Identity.Name;
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
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var brand = db.BrandsInputs.Find(id);
            if (brand == null) return HttpNotFound();
            ViewData["stageList"] = GetStageList();
            ViewData["brands"] = GetBrandList();
            return View(brand);
        }

        // POST: BrandsInput/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BrandsInput collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {

                    BrandsInput repeatbrand;
                    var userName = User.Identity.GetUserName();
                    if (string.IsNullOrEmpty(userName))
                    {
                        repeatbrand = db.BrandsInputs.FirstOrDefault(s => s.Brand == collection.Brand && s.Stage == collection.Stage && s.BrandID != collection.BrandID && s.UserId == "");
                    }
                    else
                    {
                        repeatbrand = db.BrandsInputs.FirstOrDefault(s => s.Brand == collection.Brand && s.Stage == collection.Stage && s.BrandID != collection.BrandID && s.UserId == "admin");

                    }
                    if (repeatbrand != null)
                    {
                        ModelState.AddModelError("", "已有" + collection.Brand + collection.Stage + "信息，请重新选择");
                        ViewData["stageList"] = GetStageList();
                        ViewData["brands"] = GetBrandList();
                        return View(collection);
                    }
                    db.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                    collection.UserId = User.Identity.Name;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(collection);
                }

            }
            catch
            {
                ViewData["stageList"] = GetStageList();
                ViewData["brands"] = GetBrandList();
                return View(collection);
            }
        }

        // GET: BrandsInput/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var brand = db.BrandsInputs.Find(id);
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
                var brand = db.BrandsInputs.Find(id);
                db.BrandsInputs.Remove(brand);
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
