using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;

namespace DNXTest.Controllers
{
    public class ContactWebsitesController : Controller
    {
        /*
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactWebsites
        public async Task<ActionResult> Index()
        {
            return View(await db.ContactWebsites.ToListAsync());
        }

        // GET: ContactWebsites/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactWebsite contactWebsite = await db.ContactWebsites.FindAsync(id);
            if (contactWebsite == null)
            {
                return HttpNotFound();
            }
            return View(contactWebsite);
        }

        // GET: ContactWebsites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactWebsites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,WebSite,Description")] ContactWebsite contactWebsite)
        {
            if (ModelState.IsValid)
            {
                db.ContactWebsites.Add(contactWebsite);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contactWebsite);
        }

        // GET: ContactWebsites/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactWebsite contactWebsite = await db.ContactWebsites.FindAsync(id);
            if (contactWebsite == null)
            {
                return HttpNotFound();
            }
            return View(contactWebsite);
        }

        // POST: ContactWebsites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id,WebSite,Description")] ContactWebsite contactWebsite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactWebsite).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contactWebsite);
        }

        // GET: ContactWebsites/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactWebsite contactWebsite = await db.ContactWebsites.FindAsync(id);
            if (contactWebsite == null)
            {
                return HttpNotFound();
            }
            return View(contactWebsite);
        }

        // POST: ContactWebsites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContactWebsite contactWebsite = await db.ContactWebsites.FindAsync(id);
            db.ContactWebsites.Remove(contactWebsite);
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
        }*/
    }
}
