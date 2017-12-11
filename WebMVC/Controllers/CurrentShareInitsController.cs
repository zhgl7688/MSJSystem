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
        public async Task<ActionResult> Index()
        {
            return View(await db.CurrentShareInit.ToListAsync());
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
            return View();
        }

        // POST: CurrentShareInits/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,D,E,F,G,H,Z,J")] CurrentShareInit currentShareInit)
        {
            if (ModelState.IsValid)
            {
                db.CurrentShareInit.Add(currentShareInit);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

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
                return RedirectToAction("Index");
            }
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
