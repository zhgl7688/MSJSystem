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

        public ActionResult Create()
        {
            ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", "");
            ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", "");
            var stageAddList = db.StageAdd.Where(s => s.StageType == Common.agentInputStageType.代价格管控表.ToString()).ToList();
            stageAddList.ForEach(s => s.retailPrice = "0.00");
            ViewBag.StageAdd = stageAddList;
            var stageAddList1 = db.StageAdd.Where(s => s.StageType == Common.agentInputStageType.进货表.ToString()).ToList();
            stageAddList1.ForEach(s => s.retailPrice = "0.00");
            ViewBag.StageAdd1 = stageAddList1;

            return View(new AgentInput() { });
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
                        userName = "";
                    }
                    agentInput = db.AgentInputs.FirstOrDefault(s => s.AgentName == collection.AgentName && s.Stage == collection.Stage && s.UserId == userName);

                    if (agentInput != null)
                    {
                        ModelState.AddModelError("", "已有" + collection.AgentName + collection.Stage + "信息，请重新选择");
                        ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", "");
                        ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", "");

                        ViewBag.StageAdd = SetList(collection.Stage, Common.agentInputStageType.代价格管控表.ToString());
                        ViewBag.StageAdd1 = SetList(collection.Stage, Common.agentInputStageType.进货表.ToString());

                        return View(collection);
                    }
                    collection.UserId = User.Identity.Name;

                    GetList(collection);

                    db.AgentInputs.Add(collection);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", "");
                    ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", "");
                    ViewBag.StageAdd = SetList(collection.Stage, Common.agentInputStageType.代价格管控表.ToString());
                    ViewBag.StageAdd1 = SetList(collection.Stage, Common.agentInputStageType.进货表.ToString());

                    return View();
                }
            }
            catch
            {
                ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", "");
                ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", "");
                ViewBag.StageAdd = SetList(collection.Stage, Common.agentInputStageType.代价格管控表.ToString());
                ViewBag.StageAdd1 = SetList(collection.Stage, Common.agentInputStageType.进货表.ToString());

                return View();
            }
        }

        private void GetList(AgentInput collection)
        {

            collection.PriceMange = new List<PriceMange>();
            //查找子表的键值
            var ss = db.StageAdd.Where(s => s.Stage == collection.Stage && s.StageType == Common.agentInputStageType.代价格管控表.ToString());

            foreach (var item in ss)
            {
                var value = Request.Form[item.retail] == null ? 0 : Convert.ToDecimal(Request.Form[item.retail]);

                collection.PriceMange.Add(new PriceMange { Name = item.retail, Value = value });

            }
            collection.PurchaseTable = new List<PurchaseTable>();

            //查找子表的键值
            var ss1 = db.StageAdd.Where(s => s.Stage == collection.Stage && s.StageType == Common.agentInputStageType.进货表.ToString());

            foreach (var item in ss1)
            {
                var value = Request.Form[item.retail] == null ? 0 : Convert.ToDecimal(Request.Form[item.retail]);

                collection.PurchaseTable.Add(new PurchaseTable { Name = item.retail, Value = value });

            }
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
        private List<StageAdd> SetList(AgentInput agent, string type)
        {
            var result = db.StageAdd.Where(s => s.StageType == type.ToString()).ToList();

            if (type == agentInputStageType.代价格管控表.ToString())
            {
                //查找子表的键值
                foreach (var item in result)
                {
                    foreach (var pmitem in agent.PriceMange)
                    {
                        if (item.retail == pmitem.Name)
                            item.retailPrice = pmitem.Value.ToString();
                    }

                }
            }
            else if (type == agentInputStageType.进货表.ToString())
            {
                {
                    foreach (var item in result)
                    {
                        foreach (var pmitem in agent.PurchaseTable)
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
        private List<PurchaseTable> GetPurchaseTableList(string stage)
        {
            //查找子表的键值
            var ss = db.StageAdd.Where(s => s.Stage == stage & s.StageType == Common.agentInputStageType.进货表.ToString());
            var mar = new List<PurchaseTable>();
            foreach (var item in ss)
            {
                var value = Request.Form[item.retail] == null ? 0 : Convert.ToDecimal(Request.Form[item.retail]);
                mar.Add(new PurchaseTable { Name = item.retail, Value = value });
            }

            return mar;
        }
        // GET: AgentInput/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var collection = db.AgentInputs.Find(id);
            if (collection == null) return HttpNotFound();
            ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", collection.Stage);
            ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", collection.AgentName);
            ViewBag.StageAdd = SetList(collection, Common.agentInputStageType.代价格管控表.ToString());
            ViewBag.StageAdd1 = SetList(collection, Common.agentInputStageType.进货表.ToString());


            return View(collection);
        }

        // POST: AgentInput/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "UserId")]AgentInput collection)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    AgentInput agentInput;
                    var userName = User.Identity.GetUserName();
                    if (string.IsNullOrEmpty(userName))
                    {
                        userName = "";

                    }
                    agentInput = db.AgentInputs.FirstOrDefault(
                        s => s.AgentName == collection.AgentName &&
                        s.Stage == collection.Stage &&
                        s.UserId == userName &&
                        s.AgentId != collection.AgentId);


                    if (agentInput != null)
                    {
                        ModelState.AddModelError("", "已有" + collection.AgentName + collection.Stage + "信息，请重新选择");
                        ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", "");
                        ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", "");
                        ViewBag.StageAdd = SetList(collection.Stage, Common.agentInputStageType.代价格管控表.ToString());
                        ViewBag.StageAdd1 = SetList(collection.Stage, Common.agentInputStageType.进货表.ToString());

                        return View(collection);
                    }
                    var pm = db.PriceMange.Where(s => s.AgentId == collection.AgentId);
                    var pt = db.PurchaseTable.Where(s => s.AgentId == collection.AgentId);
                    db.PriceMange.RemoveRange(pm);
                    db.PurchaseTable.RemoveRange(pt);
                    db.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                    collection.UserId = User.Identity.Name;
                    GetList(collection);
                    db.SaveChanges();


                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", collection.Stage);
                    ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", collection.AgentName);
                    ViewBag.StageAdd = SetList(collection.Stage, Common.agentInputStageType.代价格管控表.ToString());
                    ViewBag.StageAdd1 = SetList(collection.Stage, Common.agentInputStageType.进货表.ToString());

                    return View(collection);
                }


            }
            catch (Exception ex)
            {
                return Content(ex.Message.ToString());
                //  return View();
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
                brandList.Add(new SelectListItem { Text = item, Value = item });
            }
            return brandList;
        }
    }
}