using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;

namespace DNXTest.Controllers
{
    public class ContactEducationsController : Controller
    {
        /*
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactEducations
        public async Task<ActionResult> Index()
        {
            var contactEducations = db.ContactEducations.Include(c => c.Contact);
            return View(await contactEducations.ToListAsync());
        }

        // GET: ContactEducations/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactEducation contactEducation = await db.ContactEducations.FindAsync(id);
            if (contactEducation == null)
            {
                return HttpNotFound();
            }
            return View(contactEducation);
        }

        // GET: ContactEducations/Create
        public ActionResult Create()
        {
            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName");
            return View();
        }

        // POST: ContactEducations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("ContactId,DetailsOfUniversityPostGraduateOrTechnicalStudies,OtherEducationalExperience")] ContactEducation contactEducation)
        {
            if (ModelState.IsValid)
            {
                contactEducation.ContactId = Guid.NewGuid();
                db.ContactEducations.Add(contactEducation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName", contactEducation.ContactId);
            return View(contactEducation);
        }

        // GET: ContactEducations/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactEducation contactEducation = await db.ContactEducations.FindAsync(id);
            if (contactEducation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName", contactEducation.ContactId);
            return View(contactEducation);
        }

        // POST: ContactEducations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("ContactId,DetailsOfUniversityPostGraduateOrTechnicalStudies,OtherEducationalExperience")] ContactEducation contactEducation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactEducation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName", contactEducation.ContactId);
            return View(contactEducation);
        }

        // GET: ContactEducations/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactEducation contactEducation = await db.ContactEducations.FindAsync(id);
            if (contactEducation == null)
            {
                return HttpNotFound();
            }
            return View(contactEducation);
        }

        // POST: ContactEducations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ContactEducation contactEducation = await db.ContactEducations.FindAsync(id);
            db.ContactEducations.Remove(contactEducation);
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
