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
            if (User.IsInRole("品牌商")||User.IsInRole("Administrators"))
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
            ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", "");
            ViewData["brands"] = GetBrandList();
            var stageAddList = db.StageAdd.Where(s => s.StageType == Common.agentInputStageType.投资表.ToString()).ToList();
            stageAddList.ForEach(s => s.retailPrice = "0.00");
            ViewBag.StageAdd = stageAddList;
            var stageAddList1 = db.StageAdd.Where(s => s.StageType == Common.agentInputStageType.品价格管控表.ToString()).ToList();
            stageAddList1.ForEach(s => s.retailPrice = "0.00");
            ViewBag.StageAdd1 = stageAddList1;

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
                    ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", "");
                    ViewData["brands"] = GetBrandList();
                    ViewBag.StageAdd = SetList(collection.Stage, Common.agentInputStageType.投资表.ToString());
                    ViewBag.StageAdd1 = SetList(collection.Stage, Common.agentInputStageType.品价格管控表.ToString());

                    return View(collection);
                }
                var userName = User.Identity.GetUserName();
                if (string.IsNullOrEmpty(userName))
                {
                    userName = "";
                }
                else
                {
                    userName = "admin";
                }
                GetList(collection);
                collection.UserId = userName;// User.Identity.Name;
                db.BrandsInputs.Add(collection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.StageAdd = SetList(collection.Stage, Common.agentInputStageType.投资表.ToString());
                ViewBag.StageAdd1 = SetList(collection.Stage, Common.agentInputStageType.品价格管控表.ToString());

                return View();
            }
        }

        // GET: BrandsInput/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var collection = db.BrandsInputs.Find(id);
            if (collection == null) return HttpNotFound();
            ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", collection.Stage);
            ViewData["brands"] = GetBrandList();
            ViewBag.StageAdd = SetList(collection, Common.agentInputStageType.投资表.ToString());
            ViewBag.StageAdd1 = SetList(collection, Common.agentInputStageType.品价格管控表.ToString());

            return View(collection);
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
                        userName = "";
                    }
                    else
                    {
                        userName = "admin";

                    }
                    repeatbrand = db.BrandsInputs.FirstOrDefault(s => s.Brand == collection.Brand &&
                    s.Stage == collection.Stage &&
                    s.BrandID != collection.BrandID &&
                    s.UserId == userName);

                    if (repeatbrand != null)
                    {
                        ModelState.AddModelError("", "已有" + collection.Brand + collection.Stage + "信息，请重新选择");
                        ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", "");
                        ViewData["brands"] = GetBrandList();
                        return View(collection);
                    }
                    var pm = db.InvestSub.Where(s => s.BrandID == collection.BrandID);
                    var pt = db.PriceManageSub.Where(s => s.BrandID == collection.BrandID);
                    db.InvestSub.RemoveRange(pm);
                    db.PriceManageSub.RemoveRange(pt);
                    db.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                    GetList(collection);
                    collection.UserId = userName;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", "");
                    ViewData["brands"] = GetBrandList();
                    ViewBag.StageAdd = SetList(collection, Common.agentInputStageType.投资表.ToString());
                    ViewBag.StageAdd1 = SetList(collection, Common.agentInputStageType.品价格管控表.ToString());

                    return View(collection);
                }

            }
            catch
            {
                ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", "");
                ViewData["brands"] = GetBrandList();
                ViewBag.StageAdd = SetList(collection, Common.agentInputStageType.投资表.ToString());
                ViewBag.StageAdd1 = SetList(collection, Common.agentInputStageType.品价格管控表.ToString());

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
        public List<SelectListItem> GetBrandList()
        {
            List<SelectListItem> brandList = new List<SelectListItem>();
            foreach (var item in Enum.GetNames(typeof(Brand)))
            {
                brandList.Add(new SelectListItem { Text = item, Value = item });
            }
            return brandList;
        }
        private List<StageAdd> SetList(string stage, string type)
        {
            var result = db.StageAdd.Where(s => s.Stage == stage && s.StageType == type).ToList();
            //查找子表的键值
            foreach (var item in result)
            {
                item.retailPrice = Request.Form[item.retail];
            }
            return result;

        }
        private void GetList(BrandsInput collection)
        {

            collection.InvestSub = new List<InvestSub>();
            //查找子表的键值
            var ss = db.StageAdd.Where(s => s.Stage == collection.Stage && s.StageType == Common.agentInputStageType.投资表.ToString());

            foreach (var item in ss)
            {
                var value = Request.Form[item.retail] == null ? 0 : Convert.ToDecimal(Request.Form[item.retail]);

                collection.InvestSub.Add(new InvestSub { Name = item.retail, Value = value });

            }
            collection.PriceManageSub = new List<PriceManageSub>();

            //查找子表的键值
            var ss1 = db.StageAdd.Where(s => s.Stage == collection.Stage && s.StageType == Common.agentInputStageType.品价格管控表.ToString());

            foreach (var item in ss1)
            {
                var value = Request.Form[item.retail] == null ? 0 : Convert.ToDecimal(Request.Form[item.retail]);

                collection.PriceManageSub.Add(new PriceManageSub { Name = item.retail, Value = value });

            }
        }
        private List<StageAdd> SetList(BrandsInput collection, string type)
        {
            var result = db.StageAdd.Where(s => s.StageType == type.ToString()).ToList();

            if (type == agentInputStageType.投资表.ToString())
            {
                //查找子表的键值
                foreach (var item in result)
                {
                    foreach (var pmitem in collection.InvestSub)
                    {
                        if (item.retail == pmitem.Name)
                            item.retailPrice = pmitem.Value.ToString();
                    }

                }
            }
            else if (type == agentInputStageType.品价格管控表.ToString())
            {
                {
                    foreach (var item in result)
                    {
                        foreach (var pmitem in collection.PriceManageSub)
                        {
                            if (item.retail == pmitem.Name)
                                item.retailPrice = pmitem.Value.ToString();
                        }

                    }
                }
            }
            result.ForEach(s =>
            {
                if (string.IsNullOrEmpty(s.retailPrice))
                    s.retailPrice = "0.00";
            });
            return result;


        }
    }
}
