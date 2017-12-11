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
    public class ProductInnovationInitsController : Controller
    {
        private AppIdentityDbContext db = new AppIdentityDbContext();

        // GET: ProductInnovationInits
        public async Task<ActionResult> Index()
        {
            return View(await db.ProductInnovationInit.ToListAsync());
        }

        // GET: ProductInnovationInits/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInnovationInit productInnovationInit = await db.ProductInnovationInit.FindAsync(id);
            if (productInnovationInit == null)
            {
                return HttpNotFound();
            }
            return View(productInnovationInit);
        }

        // GET: ProductInnovationInits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductInnovationInits/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,ProductInnovation_M,ProductInnovation_S,ProductInnovation_J,ProductInnovation_T,ProductInnovation_AC,ProductInnovation_AL,ProductInnovation_CB1,ProductInnovation_CB2,ProductInnovation_CB3,ProductInnovation_CB4,ProductInnovation_CK1,ProductInnovation_CK2,ProductInnovation_CK3,ProductInnovation_CK4,ProductInnovation_CK5")] ProductInnovationInit productInnovationInit)
        {
            if (ModelState.IsValid)
            {
                db.ProductInnovationInit.Add(productInnovationInit);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(productInnovationInit);
        }

        // GET: ProductInnovationInits/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInnovationInit productInnovationInit = await db.ProductInnovationInit.FindAsync(id);
            if (productInnovationInit == null)
            {
                return HttpNotFound();
            }
            return View(productInnovationInit);
        }

        // POST: ProductInnovationInits/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,ProductInnovation_M,ProductInnovation_S,ProductInnovation_J,ProductInnovation_T,ProductInnovation_AC,ProductInnovation_AL,ProductInnovation_CB1,ProductInnovation_CB2,ProductInnovation_CB3,ProductInnovation_CB4,ProductInnovation_CK1,ProductInnovation_CK2,ProductInnovation_CK3,ProductInnovation_CK4,ProductInnovation_CK5")] ProductInnovationInit productInnovationInit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productInnovationInit).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productInnovationInit);
        }

        // GET: ProductInnovationInits/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInnovationInit productInnovationInit = await db.ProductInnovationInit.FindAsync(id);
            if (productInnovationInit == null)
            {
                return HttpNotFound();
            }
            return View(productInnovationInit);
        }

        // POST: ProductInnovationInits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProductInnovationInit productInnovationInit = await db.ProductInnovationInit.FindAsync(id);
            db.ProductInnovationInit.Remove(productInnovationInit);
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
