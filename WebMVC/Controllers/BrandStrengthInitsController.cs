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
    public class BrandStrengthInitsController : Controller
    {
        private AppIdentityDbContext db = new AppIdentityDbContext();

        // GET: BrandStrengthInits
        public async Task<ActionResult> Index()
        {
            return View(await db.BrandStrengthInit.ToListAsync());
        }

        // GET: BrandStrengthInits/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandStrengthInit brandStrengthInit = await db.BrandStrengthInit.FindAsync(id);
            if (brandStrengthInit == null)
            {
                return HttpNotFound();
            }
            return View(brandStrengthInit);
        }

        // GET: BrandStrengthInits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrandStrengthInits/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,BrandStrength_E,BrandStrength_M1,BrandStrength_M2,BrandStrength_Agent,lastM,currentM")] BrandStrengthInit brandStrengthInit)
        {
            if (ModelState.IsValid)
            {
                db.BrandStrengthInit.Add(brandStrengthInit);
                await db.SaveChangesAsync();
                return RedirectToAction("Index","home");
            }

            return View(brandStrengthInit);
        }

        // GET: BrandStrengthInits/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandStrengthInit brandStrengthInit = await db.BrandStrengthInit.FindAsync(id);
            if (brandStrengthInit == null)
            {
                return HttpNotFound();
            }
            return View(brandStrengthInit);
        }

        // POST: BrandStrengthInits/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,BrandStrength_E,BrandStrength_M1,BrandStrength_M2,BrandStrength_Agent,lastM,currentM")] BrandStrengthInit brandStrengthInit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brandStrengthInit).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(brandStrengthInit);
        }

        // GET: BrandStrengthInits/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandStrengthInit brandStrengthInit = await db.BrandStrengthInit.FindAsync(id);
            if (brandStrengthInit == null)
            {
                return HttpNotFound();
            }
            return View(brandStrengthInit);
        }

        // POST: BrandStrengthInits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BrandStrengthInit brandStrengthInit = await db.BrandStrengthInit.FindAsync(id);
            db.BrandStrengthInit.Remove(brandStrengthInit);
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
