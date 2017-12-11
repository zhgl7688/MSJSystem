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
    public class ChannelServiceInitsController : Controller
    {
        private AppIdentityDbContext db = new AppIdentityDbContext();

        // GET: ChannelServiceInits
        public async Task<ActionResult> Index()
        {
            return View(await db.ChannelServiceInit.ToListAsync());
        }

        // GET: ChannelServiceInits/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChannelServiceInit channelServiceInit = await db.ChannelServiceInit.FindAsync(id);
            if (channelServiceInit == null)
            {
                return HttpNotFound();
            }
            return View(channelServiceInit);
        }

        // GET: ChannelServiceInits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChannelServiceInits/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,ChannelService_J1,ChannelService_J2")] ChannelServiceInit channelServiceInit)
        {
            if (ModelState.IsValid)
            {
                db.ChannelServiceInit.Add(channelServiceInit);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(channelServiceInit);
        }

        // GET: ChannelServiceInits/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChannelServiceInit channelServiceInit = await db.ChannelServiceInit.FindAsync(id);
            if (channelServiceInit == null)
            {
                return HttpNotFound();
            }
            return View(channelServiceInit);
        }

        // POST: ChannelServiceInits/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,ChannelService_J1,ChannelService_J2")] ChannelServiceInit channelServiceInit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(channelServiceInit).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(channelServiceInit);
        }

        // GET: ChannelServiceInits/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChannelServiceInit channelServiceInit = await db.ChannelServiceInit.FindAsync(id);
            if (channelServiceInit == null)
            {
                return HttpNotFound();
            }
            return View(channelServiceInit);
        }

        // POST: ChannelServiceInits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ChannelServiceInit channelServiceInit = await db.ChannelServiceInit.FindAsync(id);
            db.ChannelServiceInit.Remove(channelServiceInit);
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
