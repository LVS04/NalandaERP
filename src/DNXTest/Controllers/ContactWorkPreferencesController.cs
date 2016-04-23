using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;

namespace DNXTest.Controllers
{
    public class ContactWorkPreferencesController : Controller
    {
        /*
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactWorkPreferences
        public async Task<ActionResult> Index()
        {
            var contactWorkPreferences = db.ContactWorkPreferences.Include(c => c.Contact);
            return View(await contactWorkPreferences.ToListAsync());
        }

        // GET: ContactWorkPreferences/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactWorkPreference contactWorkPreference = await db.ContactWorkPreferences.FindAsync(id);
            if (contactWorkPreference == null)
            {
                return HttpNotFound();
            }
            return View(contactWorkPreference);
        }

        // GET: ContactWorkPreferences/Create
        public ActionResult Create()
        {
            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName");
            return View();
        }

        // POST: ContactWorkPreferences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("ContactId,Cooking,Maintenance,Gardening,Cleaning,IT,Office,ArtWorkshop,ExperienceOnWorkAreas,WorkAreasExclusionAndReasons,ReasonsToOfferVoluntaryWorkToCenter,WhenToComeStartDate,WhenToComeEndDate,HopesExpectationsForStay,SkillsAndKnowledgesToDevelopDuringStay,HowDidContactFoundTheCenter")] ContactWorkPreference contactWorkPreference)
        {
            if (ModelState.IsValid)
            {
                contactWorkPreference.ContactId = Guid.NewGuid();
                db.ContactWorkPreferences.Add(contactWorkPreference);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName", contactWorkPreference.ContactId);
            return View(contactWorkPreference);
        }

        // GET: ContactWorkPreferences/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactWorkPreference contactWorkPreference = await db.ContactWorkPreferences.FindAsync(id);
            if (contactWorkPreference == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName", contactWorkPreference.ContactId);
            return View(contactWorkPreference);
        }

        // POST: ContactWorkPreferences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("ContactId,Cooking,Maintenance,Gardening,Cleaning,IT,Office,ArtWorkshop,ExperienceOnWorkAreas,WorkAreasExclusionAndReasons,ReasonsToOfferVoluntaryWorkToCenter,WhenToComeStartDate,WhenToComeEndDate,HopesExpectationsForStay,SkillsAndKnowledgesToDevelopDuringStay,HowDidContactFoundTheCenter")] ContactWorkPreference contactWorkPreference)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactWorkPreference).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName", contactWorkPreference.ContactId);
            return View(contactWorkPreference);
        }

        // GET: ContactWorkPreferences/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactWorkPreference contactWorkPreference = await db.ContactWorkPreferences.FindAsync(id);
            if (contactWorkPreference == null)
            {
                return HttpNotFound();
            }
            return View(contactWorkPreference);
        }

        // POST: ContactWorkPreferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ContactWorkPreference contactWorkPreference = await db.ContactWorkPreferences.FindAsync(id);
            db.ContactWorkPreferences.Remove(contactWorkPreference);
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
