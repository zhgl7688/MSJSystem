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
        InvertmentTable1 invertmentTable1;
        List<BrandTable> brands;
        public BrandsInputController()
        {
            invertmentTable1 = new InvertmentTable1();
             brands = invertmentTable1.getBrandTable();
        }


        public ActionResult Index()
        {

            return View(brands);
        }

        // GET: BrandsInput/Details/5
        public ActionResult Details(int id)
        {
            var brand = brands.FirstOrDefault(s => s.BrandID == id);
            return View(brand);
        }

        // GET: BrandsInput/Create
        public ActionResult Create()
        {
            ViewData["stageList"] = GetStageList();
            ViewData["brands"] = GetBrandList();
            return View(new BrandTable());
        }

        // POST: BrandsInput/Create
        [HttpPost]
        public ActionResult Create(BrandsInput collection)
        {
            try
            {
               var brand= db.BrandsInputs.FirstOrDefault(s => s.Brand == collection.Brand && s.Stage == collection.Stage);
                if (brand != null)
                {
                    return Content("<script>alert('已有"+collection.Brand + collection.Stage + "信息，请重新选择');location='" + Url.Action("Create", "BrandsInput") + "'</script>");
                }
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
            var brand = brands.FirstOrDefault(s => s.BrandID == id);
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
                var brand = brands.FirstOrDefault(s => s.BrandID == id);
                brands.Remove(brand);
                brands.Add(collection);
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
            return View();
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
