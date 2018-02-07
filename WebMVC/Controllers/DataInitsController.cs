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
    public class DataInitsController : Controller
    {
        private AppIdentityDbContext db = new AppIdentityDbContext();

        // GET: DataInits
        public async Task<ActionResult> Index()
        {
            return View(await db.DataInits.ToListAsync());
        }

        // GET: DataInits/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataInit dataInit = await db.DataInits.FindAsync(id);
            if (dataInit == null)
            {
                return HttpNotFound();
            }
            return View(dataInit);
        }

        // GET: DataInits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataInits/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,BrandStrength_E,BrandStrength_M1,BrandStrength_M2,BrandStrength_Agent,lastM,currentM,ChannelService_J1,ChannelService_J2,CD,CE,CF,CM,CN,CO,M_GrossMargin,M_promotional,M_Year,M_FixedCharges,S_GrossMargin,S_promotional,S_Year,S_FixedCharges,J_GrossMargin,J_promotional,J_Year,J_FixedCharges,price_M,price_S,price_J,priceIndex_M,priceIndex_S,priceIndex_J,MarketPromotionInit_AY1,MarketPromotionInit_AY2,MarketPromotionInit_AX1,MarketPromotionInit_AX2,MarketPromotionInit_AX3,MarketPromotionInit_AX4,MarketPromotionInit_AX5,MarketPromotionInit_AX6,ProductInnovation_M,ProductInnovation_S,ProductInnovation_J,ProductInnovation_T,ProductInnovation_AC,ProductInnovation_AL,ProductInnovation_CB1,ProductInnovation_CB2,ProductInnovation_CB3,ProductInnovation_CB4,ProductInnovation_CB5,ProductInnovation_CK1,ProductInnovation_CK2,ProductInnovation_CK3,ProductInnovation_CK4,ProductInnovation_CK5")] DataInit dataInit)
        {
              if (ModelState.IsValid)
            {
                db.DataInits.Add(dataInit);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dataInit);
        }

        // GET: DataInits/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataInit dataInit = await db.DataInits.FindAsync(id);
            if (dataInit == null)
            {
                return HttpNotFound();
            }
            return View(dataInit);
        }

        // POST: DataInits/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,BrandStrength_E,BrandStrength_M1,BrandStrength_M2,BrandStrength_Agent,lastM,currentM,ChannelService_J1,ChannelService_J2,CD,CE,CF,CM,CN,CO,M_GrossMargin,M_promotional,M_Year,M_FixedCharges,S_GrossMargin,S_promotional,S_Year,S_FixedCharges,J_GrossMargin,J_promotional,J_Year,J_FixedCharges,price_M,price_S,price_J,priceIndex_M,priceIndex_S,priceIndex_J,MarketPromotionInit_AY1,MarketPromotionInit_AY2,MarketPromotionInit_AX1,MarketPromotionInit_AX2,MarketPromotionInit_AX3,MarketPromotionInit_AX4,MarketPromotionInit_AX5,MarketPromotionInit_AX6,ProductInnovation_M,ProductInnovation_S,ProductInnovation_J,ProductInnovation_T,ProductInnovation_AC,ProductInnovation_AL,ProductInnovation_CB1,ProductInnovation_CB2,ProductInnovation_CB3,ProductInnovation_CB4,ProductInnovation_CB5,ProductInnovation_CK1,ProductInnovation_CK2,ProductInnovation_CK3,ProductInnovation_CK4,ProductInnovation_CK5")] DataInit dataInit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dataInit).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return View(dataInit);// RedirectToAction("Index");
            }
            return View(dataInit);
        }

        // GET: DataInits/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataInit dataInit = await db.DataInits.FindAsync(id);
            if (dataInit == null)
            {
                return HttpNotFound();
            }
            return View(dataInit);
        }

        // POST: DataInits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DataInit dataInit = await db.DataInits.FindAsync(id);
            db.DataInits.Remove(dataInit);
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
