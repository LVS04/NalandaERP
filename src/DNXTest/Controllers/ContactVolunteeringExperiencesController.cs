using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;

namespace DNXTest.Controllers
{
    public class ContactVolunteeringExperiencesController : Controller
    {
        /*
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactVolunteeringExperiences
        public async Task<ActionResult> Index()
        {
            return View(await db.ContactVolunteeringExperiences.ToListAsync());
        }

        // GET: ContactVolunteeringExperiences/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactVolunteeringExperience contactVolunteeringExperience = await db.ContactVolunteeringExperiences.FindAsync(id);
            if (contactVolunteeringExperience == null)
            {
                return HttpNotFound();
            }
            return View(contactVolunteeringExperience);
        }

        // GET: ContactVolunteeringExperiences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactVolunteeringExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("ContactId,DetailsOfMainWorkAndVolunteerinExperience")] ContactVolunteeringExperience contactVolunteeringExperience)
        {
            if (ModelState.IsValid)
            {
                contactVolunteeringExperience.ContactId = Guid.NewGuid();
                db.ContactVolunteeringExperiences.Add(contactVolunteeringExperience);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contactVolunteeringExperience);
        }

        // GET: ContactVolunteeringExperiences/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactVolunteeringExperience contactVolunteeringExperience = await db.ContactVolunteeringExperiences.FindAsync(id);
            if (contactVolunteeringExperience == null)
            {
                return HttpNotFound();
            }
            return View(contactVolunteeringExperience);
        }

        // POST: ContactVolunteeringExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("ContactId,DetailsOfMainWorkAndVolunteerinExperience")] ContactVolunteeringExperience contactVolunteeringExperience)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactVolunteeringExperience).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contactVolunteeringExperience);
        }

        // GET: ContactVolunteeringExperiences/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactVolunteeringExperience contactVolunteeringExperience = await db.ContactVolunteeringExperiences.FindAsync(id);
            if (contactVolunteeringExperience == null)
            {
                return HttpNotFound();
            }
            return View(contactVolunteeringExperience);
        }

        // POST: ContactVolunteeringExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ContactVolunteeringExperience contactVolunteeringExperience = await db.ContactVolunteeringExperiences.FindAsync(id);
            db.ContactVolunteeringExperiences.Remove(contactVolunteeringExperience);
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
