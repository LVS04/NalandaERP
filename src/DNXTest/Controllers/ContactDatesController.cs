using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;

namespace DNXTest.Controllers
{
    public class ContactDatesController : Controller
    {
        /*
        private readonly GenericRepository<Contact> RepoContact;
        private readonly ApplicationDbContext db;

        public ContactDatesController(ApplicationDbContext context)
        {
            RepoContact = new GenericRepository<Contact>(context);
            db = context;
        }

        // GET: ContactDates
        public async Task<ActionResult> Index()
        {
            return View(await db.ContactDates.ToListAsync());
        }

        // GET: ContactDates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDate contactDate = await db.ContactDates.FindAsync(id);
            if (contactDate == null)
            {
                return HttpNotFound();
            }
            return View(contactDate);
        }

        // GET: ContactDates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactDates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Date,Description")] ContactDate contactDate)
        {
            if (ModelState.IsValid)
            {
                db.ContactDates.Add(contactDate);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contactDate);
        }

        // GET: ContactDates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDate contactDate = await db.ContactDates.FindAsync(id);
            if (contactDate == null)
            {
                return HttpNotFound();
            }
            return View(contactDate);
        }

        // POST: ContactDates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id,Date,Description")] ContactDate contactDate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactDate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contactDate);
        }

        // GET: ContactDates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDate contactDate = await db.ContactDates.FindAsync(id);
            if (contactDate == null)
            {
                return HttpNotFound();
            }
            return View(contactDate);
        }

        // POST: ContactDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContactDate contactDate = await db.ContactDates.FindAsync(id);
            db.ContactDates.Remove(contactDate);
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
