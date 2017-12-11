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
    public class MarketPromotionInitsController : Controller
    {
        private AppIdentityDbContext db = new AppIdentityDbContext();

        // GET: MarketPromotionInits
        public async Task<ActionResult> Index()
        {
            return View(await db.MarketPromotionInit.ToListAsync());
        }

        // GET: MarketPromotionInits/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarketPromotionInit marketPromotionInit = await db.MarketPromotionInit.FindAsync(id);
            if (marketPromotionInit == null)
            {
                return HttpNotFound();
            }
            return View(marketPromotionInit);
        }

        // GET: MarketPromotionInits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarketPromotionInits/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,MarketPromotionInit_AY1,MarketPromotionInit_AY2,MarketPromotionInit_AX1,MarketPromotionInit_AX2,MarketPromotionInit_AX3,MarketPromotionInit_AX4,MarketPromotionInit_AX5,MarketPromotionInit_AX6")] MarketPromotionInit marketPromotionInit)
        {
            if (ModelState.IsValid)
            {
                db.MarketPromotionInit.Add(marketPromotionInit);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(marketPromotionInit);
        }

        // GET: MarketPromotionInits/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarketPromotionInit marketPromotionInit = await db.MarketPromotionInit.FindAsync(id);
            if (marketPromotionInit == null)
            {
                return HttpNotFound();
            }
            return View(marketPromotionInit);
        }

        // POST: MarketPromotionInits/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,MarketPromotionInit_AY1,MarketPromotionInit_AY2,MarketPromotionInit_AX1,MarketPromotionInit_AX2,MarketPromotionInit_AX3,MarketPromotionInit_AX4,MarketPromotionInit_AX5,MarketPromotionInit_AX6")] MarketPromotionInit marketPromotionInit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marketPromotionInit).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(marketPromotionInit);
        }

        // GET: MarketPromotionInits/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarketPromotionInit marketPromotionInit = await db.MarketPromotionInit.FindAsync(id);
            if (marketPromotionInit == null)
            {
                return HttpNotFound();
            }
            return View(marketPromotionInit);
        }

        // POST: MarketPromotionInits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MarketPromotionInit marketPromotionInit = await db.MarketPromotionInit.FindAsync(id);
            db.MarketPromotionInit.Remove(marketPromotionInit);
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
