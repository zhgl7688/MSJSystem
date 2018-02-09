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

namespace WebMVC.Controllers
{
    public class CurrentShareInitsController : Controller
    {
        private AppIdentityDbContext db = new AppIdentityDbContext();

        // GET: CurrentShareInits
        [ChildActionOnly]
        public ActionResult Index()
        {

            return PartialView("_share",db.CurrentShareInit.ToList());
        }

        // GET: CurrentShareInits/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentShareInit currentShareInit = await db.CurrentShareInit.FindAsync(id);
            if (currentShareInit == null)
            {
                return HttpNotFound();
            }
            return View(currentShareInit);
        }

        // GET: CurrentShareInits/Create
        public ActionResult Create()
        {
            ViewBag.G = new SelectList(db.CodeInit.Where(s => s.Code == "Stage"), "Text", "Text", "");
            // ViewBag.AgentName = new SelectList(db.CodeInit.Where(s => s.Code == "Agent"), "Text", "Text", "");
            return View(new CurrentShareInit {  D=0, E=0,F=0, H=0, AR=0,Z=0});
        }

        // POST: CurrentShareInits/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,D,E,F,G,H,Z,J")] CurrentShareInit currentShareInit)//
        {
            if (ModelState.IsValid)
            {
                var DD = db.CurrentShareInit.FirstOrDefault(s => s.G == currentShareInit.G);

                if (DD != null)
                {
                    ModelState.AddModelError("", "已有" + currentShareInit.G + "信息，请重新选择");
                    ViewBag.G = new SelectList(db.CodeInit.Where(s => s.Code == "Stage"), "Text", "Text", currentShareInit.G);
                    return View(currentShareInit);
                }
                db.CurrentShareInit.Add(currentShareInit);
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", "DataInits", new { id = 1 });
               // return RedirectToAction("Index");
            }
            ViewBag.G = new SelectList(db.CodeInit.Where(s => s.Code == "Stage"), "Text", "Text", currentShareInit.G);

            return View(currentShareInit);
        }

        // GET: CurrentShareInits/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CurrentShareInit currentShareInit = await db.CurrentShareInit.FindAsync(id);
            if (currentShareInit == null)
            {
                return HttpNotFound();
            }
            ViewBag.G = new SelectList(db.CodeInit.Where(s => s.Code == "Stage"), "Text", "Text", currentShareInit.G);
            return View(currentShareInit);
        }

        // POST: CurrentShareInits/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,D,E,F,G,H,Z,J")] CurrentShareInit currentShareInit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currentShareInit).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", "DataInits", new { id = 1 });// return RedirectToAction("Index");
            }
           // ViewBag.G = new SelectList(db.CodeInit.Where(s => s.Code == "Stage"  ), "Text", "Text", currentShareInit.G);

        
             return View(currentShareInit);
        }

        // GET: CurrentShareInits/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentShareInit currentShareInit = await db.CurrentShareInit.FindAsync(id);
            if (currentShareInit == null)
            {
                return HttpNotFound();
            }
            return View(currentShareInit);
        }

        // POST: CurrentShareInits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CurrentShareInit currentShareInit = await db.CurrentShareInit.FindAsync(id);
            db.CurrentShareInit.Remove(currentShareInit);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
