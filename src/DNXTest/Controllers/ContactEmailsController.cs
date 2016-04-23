using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;

namespace DNXTest.Controllers
{
    public class ContactEmailsController : Controller
    {
      /*  private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactEmails
        public async Task<ActionResult> Index()
        {
            return View(await db.ContactEmails.ToListAsync());
        }

        // GET: ContactEmails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactEmail contactEmail = await db.ContactEmails.FindAsync(id);
            if (contactEmail == null)
            {
                return HttpNotFound();
            }
            return View(contactEmail);
        }

        // GET: ContactEmails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactEmails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Email,Description")] ContactEmail contactEmail)
        {
            if (ModelState.IsValid)
            {
                db.ContactEmails.Add(contactEmail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contactEmail);
        }

        // GET: ContactEmails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactEmail contactEmail = await db.ContactEmails.FindAsync(id);
            if (contactEmail == null)
            {
                return HttpNotFound();
            }
            return View(contactEmail);
        }

        // POST: ContactEmails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id,Email,Description")] ContactEmail contactEmail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactEmail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contactEmail);
        }

        // GET: ContactEmails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactEmail contactEmail = await db.ContactEmails.FindAsync(id);
            if (contactEmail == null)
            {
                return HttpNotFound();
            }
            return View(contactEmail);
        }

        // POST: ContactEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContactEmail contactEmail = await db.ContactEmails.FindAsync(id);
            db.ContactEmails.Remove(contactEmail);
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
