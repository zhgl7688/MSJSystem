using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMVC.Infrastructure;
using WebMVC.Models;
using WebMVC.Common;

namespace WebMVC.Controllers
{
    public class StageAddsController : Controller
    {
        private AppIdentityDbContext db = new AppIdentityDbContext();

        // GET: StageAdds
        public async Task<ActionResult> Index()
        {
            return View(await db.StageAdd.ToListAsync());
        }

        // GET: StageAdds/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StageAdd stageAdd = await db.StageAdd.FindAsync(id);
            if (stageAdd == null)
            {
                return HttpNotFound();
            }
            return View(stageAdd);
        }

        // GET: StageAdds/Create
        public ActionResult Create()
        {
            ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", "");
            ViewBag.StageType = new SelectList(this.getstageType, "Text", "Text", "");
            return View();
        }

        // POST: StageAdds/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,StageType,Stage,retail")] StageAdd stageAdd)
        {
            if (ModelState.IsValid)
            {
                db.StageAdd.Add(stageAdd);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", "");

            ViewBag.StageType = new SelectList(this.getstageType, "Text", "Text", "");

            return View(stageAdd);
        }

        // GET: StageAdds/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StageAdd stageAdd = await db.StageAdd.FindAsync(id);
            if (stageAdd == null)
            {
                return HttpNotFound();
            }
            ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", stageAdd.Stage);
            ViewBag.StageType = new SelectList(this.getstageType, "Text", "Text", stageAdd.StageType);
            return View(stageAdd);
        }

        // POST: StageAdds/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,StageType,Stage,retail,retailPrice")] StageAdd stageAdd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stageAdd).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Stage = new SelectList(db.CodeInit.Where(s => s.Code == "Stage" && s.Value != 0), "Text", "Text", stageAdd.Stage);
            ViewBag.StageType = new SelectList(this.getstageType, "Text", "Text", stageAdd.StageType);
            return View(stageAdd);
        }

        // GET: StageAdds/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StageAdd stageAdd = await db.StageAdd.FindAsync(id);
            if (stageAdd == null)
            {
                return HttpNotFound();
            }
            return View(stageAdd);
        }

        // POST: StageAdds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StageAdd stageAdd = await db.StageAdd.FindAsync(id);
            db.StageAdd.Remove(stageAdd);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        private List<CodeInit> getstageType
        {
            get
            {
                var stageType = new List<CodeInit>();
 
                stageType.Add(new CodeInit { Text = agentInputStageType.价格管控表.ToString()});
                stageType.Add(new CodeInit { Text = agentInputStageType.进货表.ToString()  });
                return stageType;
            }

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
