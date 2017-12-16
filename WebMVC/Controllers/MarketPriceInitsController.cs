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
    public class MarketPriceInitsController : Controller
    {
        private AppIdentityDbContext db = new AppIdentityDbContext();

        // GET: MarketPriceInits
        public async Task<ActionResult> Index()
        {
            return View(await db.MarketPriceInit.ToListAsync());
        }

        // GET: MarketPriceInits/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarketPriceInit marketPriceInit = await db.MarketPriceInit.FindAsync(id);
            if (marketPriceInit == null)
            {
                return HttpNotFound();
            }
            return View(marketPriceInit);
        }

        // GET: MarketPriceInits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarketPriceInits/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,CD,CE,CF,CM,CN,CO,M_GrossMargin,M_promotional,price_M,price_S,price_J,priceIndex_M,priceIndex_S,priceIndex_J")] MarketPriceInit marketPriceInit)
        {
            if (ModelState.IsValid)
            {
                db.MarketPriceInit.Add(marketPriceInit);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(marketPriceInit);
        }

        // GET: MarketPriceInits/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarketPriceInit marketPriceInit = await db.MarketPriceInit.FindAsync(id);
            if (marketPriceInit == null)
            {
                return HttpNotFound();
            }
            return View(marketPriceInit);
        }

        // POST: MarketPriceInits/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MarketPriceInit marketPriceInit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marketPriceInit).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View(marketPriceInit);
        }

        // GET: MarketPriceInits/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarketPriceInit marketPriceInit = await db.MarketPriceInit.FindAsync(id);
            if (marketPriceInit == null)
            {
                return HttpNotFound();
            }
            return View(marketPriceInit);
        }

        // POST: MarketPriceInits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MarketPriceInit marketPriceInit = await db.MarketPriceInit.FindAsync(id);
            db.MarketPriceInit.Remove(marketPriceInit);
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
