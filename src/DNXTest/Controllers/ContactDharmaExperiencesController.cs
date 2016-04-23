using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;

namespace DNXTest.Controllers
{
    public class ContactDharmaExperiencesController : Controller
    {
        /*
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactDharmaExperiences
        public async Task<ActionResult> Index()
        {
            var contactDharmaExperiences = db.ContactDharmaExperiences.Include(c => c.Contact);
            return View(await contactDharmaExperiences.ToListAsync());
        }

        // GET: ContactDharmaExperiences/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDharmaExperience contactDharmaExperience = await db.ContactDharmaExperiences.FindAsync(id);
            if (contactDharmaExperience == null)
            {
                return HttpNotFound();
            }
            return View(contactDharmaExperience);
        }

        // GET: ContactDharmaExperiences/Create
        public ActionResult Create()
        {
            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName");
            return View();
        }

        // POST: ContactDharmaExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("ContactId,FollowerOfReligionWhich,InterestInFollowingTeachings,DescriptionOfBuddhistBackgroundOfAnyTradition")] ContactDharmaExperience contactDharmaExperience)
        {
            if (ModelState.IsValid)
            {
                contactDharmaExperience.ContactId = Guid.NewGuid();
                db.ContactDharmaExperiences.Add(contactDharmaExperience);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName", contactDharmaExperience.ContactId);
            return View(contactDharmaExperience);
        }

        // GET: ContactDharmaExperiences/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDharmaExperience contactDharmaExperience = await db.ContactDharmaExperiences.FindAsync(id);
            if (contactDharmaExperience == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName", contactDharmaExperience.ContactId);
            return View(contactDharmaExperience);
        }

        // POST: ContactDharmaExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("ContactId,FollowerOfReligionWhich,InterestInFollowingTeachings,DescriptionOfBuddhistBackgroundOfAnyTradition")] ContactDharmaExperience contactDharmaExperience)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactDharmaExperience).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName", contactDharmaExperience.ContactId);
            return View(contactDharmaExperience);
        }

        // GET: ContactDharmaExperiences/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDharmaExperience contactDharmaExperience = await db.ContactDharmaExperiences.FindAsync(id);
            if (contactDharmaExperience == null)
            {
                return HttpNotFound();
            }
            return View(contactDharmaExperience);
        }

        // POST: ContactDharmaExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ContactDharmaExperience contactDharmaExperience = await db.ContactDharmaExperiences.FindAsync(id);
            db.ContactDharmaExperiences.Remove(contactDharmaExperience);
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
