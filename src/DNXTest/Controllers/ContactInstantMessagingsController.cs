using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;

namespace DNXTest.Controllers
{
    public class ContactInstantMessagingsController : Controller
    {
        /*
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactInstantMessagings
        public async Task<ActionResult> Index()
        {
            return View(await db.ContactInstantMessagings.ToListAsync());
        }

        // GET: ContactInstantMessagings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInstantMessaging contactInstantMessaging = await db.ContactInstantMessagings.FindAsync(id);
            if (contactInstantMessaging == null)
            {
                return HttpNotFound();
            }
            return View(contactInstantMessaging);
        }

        // GET: ContactInstantMessagings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactInstantMessagings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,InstantMessaging,IMContact")] ContactInstantMessaging contactInstantMessaging)
        {
            if (ModelState.IsValid)
            {
                db.ContactInstantMessagings.Add(contactInstantMessaging);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contactInstantMessaging);
        }

        // GET: ContactInstantMessagings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInstantMessaging contactInstantMessaging = await db.ContactInstantMessagings.FindAsync(id);
            if (contactInstantMessaging == null)
            {
                return HttpNotFound();
            }
            return View(contactInstantMessaging);
        }

        // POST: ContactInstantMessagings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id,InstantMessaging,IMContact")] ContactInstantMessaging contactInstantMessaging)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactInstantMessaging).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contactInstantMessaging);
        }

        // GET: ContactInstantMessagings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInstantMessaging contactInstantMessaging = await db.ContactInstantMessagings.FindAsync(id);
            if (contactInstantMessaging == null)
            {
                return HttpNotFound();
            }
            return View(contactInstantMessaging);
        }

        // POST: ContactInstantMessagings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContactInstantMessaging contactInstantMessaging = await db.ContactInstantMessagings.FindAsync(id);
            db.ContactInstantMessagings.Remove(contactInstantMessaging);
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
