using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;

namespace DNXTest.Controllers
{
    public class ContactDonorInfoesController : Controller
    {
        /*
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactDonorInfoes
        public async Task<ActionResult> Index()
        {
            var contactDonorInfoes = db.ContactDonorInfoes.Include(c => c.Contact);
            return View(await contactDonorInfoes.ToListAsync());
        }

        // GET: ContactDonorInfoes/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDonorInfo contactDonorInfo = await db.ContactDonorInfoes.FindAsync(id);
            if (contactDonorInfo == null)
            {
                return HttpNotFound();
            }
            return View(contactDonorInfo);
        }

        // GET: ContactDonorInfoes/Create
        public ActionResult Create()
        {
            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName");
            return View();
        }

        // POST: ContactDonorInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("ContactId")] ContactDonorInfo contactDonorInfo)
        {
            if (ModelState.IsValid)
            {
                contactDonorInfo.ContactId = Guid.NewGuid();
                db.ContactDonorInfoes.Add(contactDonorInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName", contactDonorInfo.ContactId);
            return View(contactDonorInfo);
        }

        // GET: ContactDonorInfoes/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDonorInfo contactDonorInfo = await db.ContactDonorInfoes.FindAsync(id);
            if (contactDonorInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName", contactDonorInfo.ContactId);
            return View(contactDonorInfo);
        }

        // POST: ContactDonorInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("ContactId")] ContactDonorInfo contactDonorInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactDonorInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName", contactDonorInfo.ContactId);
            return View(contactDonorInfo);
        }

        // GET: ContactDonorInfoes/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDonorInfo contactDonorInfo = await db.ContactDonorInfoes.FindAsync(id);
            if (contactDonorInfo == null)
            {
                return HttpNotFound();
            }
            return View(contactDonorInfo);
        }

        // POST: ContactDonorInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ContactDonorInfo contactDonorInfo = await db.ContactDonorInfoes.FindAsync(id);
            db.ContactDonorInfoes.Remove(contactDonorInfo);
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
