using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;

namespace DNXTest.Controllers
{
    public class ContactRelatedsController : Controller
    {
        /*
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactRelateds
        public async Task<ActionResult> Index()
        {
            return View(await db.ContactRelateds.ToListAsync());
        }

        // GET: ContactRelateds/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactRelated contactRelated = await db.ContactRelateds.FindAsync(id);
            if (contactRelated == null)
            {
                return HttpNotFound();
            }
            return View(contactRelated);
        }

        // GET: ContactRelateds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactRelateds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id")] ContactRelated contactRelated)
        {
            if (ModelState.IsValid)
            {
                db.ContactRelateds.Add(contactRelated);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contactRelated);
        }

        // GET: ContactRelateds/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactRelated contactRelated = await db.ContactRelateds.FindAsync(id);
            if (contactRelated == null)
            {
                return HttpNotFound();
            }
            return View(contactRelated);
        }

        // POST: ContactRelateds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id")] ContactRelated contactRelated)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactRelated).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contactRelated);
        }

        // GET: ContactRelateds/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactRelated contactRelated = await db.ContactRelateds.FindAsync(id);
            if (contactRelated == null)
            {
                return HttpNotFound();
            }
            return View(contactRelated);
        }

        // POST: ContactRelateds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContactRelated contactRelated = await db.ContactRelateds.FindAsync(id);
            db.ContactRelateds.Remove(contactRelated);
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
