//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using asp.net.test.Models;

//namespace asp.net.test.Controllers
//{
//    public class ContactController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: Contact
//        public async Task<ActionResult> Index()
//        {
//            var contact = db.contact.Include(c => c.ContactDharmaExperience).Include(c => c.ContactDonorInfo).Include(c => c.ContactEducation).Include(c => c.ContactHealthInfo).Include(c => c.ContactIdentification).Include(c => c.ContactWorkPreference);
//            return View(await contact.ToListAsync());
//        }

//        // GET: Contact/Details/5
//        public async Task<ActionResult> Details(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Contact contact = await db.contact.FindAsync(id);
//            if (contact == null)
//            {
//                return HttpNotFound();
//            }
//            return View(contact);
//        }

//        // GET: Contact/Create
//        public ActionResult Create()
//        {
//            ViewBag.Id = new SelectList(db.ContactDharmaExperiences, "ContactId", "FollowerOfReligionWhich");
//            ViewBag.Id = new SelectList(db.ContactDonorInfoes, "ContactId", "ContactId");
//            ViewBag.Id = new SelectList(db.ContactEducations, "ContactId", "DetailsOfUniversityPostGraduateOrTechnicalStudies");
//            ViewBag.Id = new SelectList(db.ContactHealthInfoes, "ContactId", "AllergiesToMedications");
//            ViewBag.Id = new SelectList(db.ContactIdentifications, "ContactId", "IdOrPassport");
//            ViewBag.Id = new SelectList(db.ContactWorkPreferences, "ContactId", "ExperienceOnWorkAreas");
//            return View();
//        }

//        // POST: Contact/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Create([Bind(Include = "Id,ContactName,Prefix,FirstName,LastName,Suffix,Gender,PositionAndCompany,NickName,Notes,HistoryWithTheCenter,FoodAllergies,Birthdate")] Contact contact)
//        {
//            if (ModelState.IsValid)
//            {
//                contact.Id = Guid.NewGuid();
//                db.contact.Add(contact);
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }

//            ViewBag.Id = new SelectList(db.ContactDharmaExperiences, "ContactId", "FollowerOfReligionWhich", contact.Id);
//            ViewBag.Id = new SelectList(db.ContactDonorInfoes, "ContactId", "ContactId", contact.Id);
//            ViewBag.Id = new SelectList(db.ContactEducations, "ContactId", "DetailsOfUniversityPostGraduateOrTechnicalStudies", contact.Id);
//            ViewBag.Id = new SelectList(db.ContactHealthInfoes, "ContactId", "AllergiesToMedications", contact.Id);
//            ViewBag.Id = new SelectList(db.ContactIdentifications, "ContactId", "IdOrPassport", contact.Id);
//            ViewBag.Id = new SelectList(db.ContactWorkPreferences, "ContactId", "ExperienceOnWorkAreas", contact.Id);
//            return View(contact);
//        }

//        // GET: Contact/Edit/5
//        public async Task<ActionResult> Edit(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Contact contact = await db.contact.FindAsync(id);
//            if (contact == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.Id = new SelectList(db.ContactDharmaExperiences, "ContactId", "FollowerOfReligionWhich", contact.Id);
//            ViewBag.Id = new SelectList(db.ContactDonorInfoes, "ContactId", "ContactId", contact.Id);
//            ViewBag.Id = new SelectList(db.ContactEducations, "ContactId", "DetailsOfUniversityPostGraduateOrTechnicalStudies", contact.Id);
//            ViewBag.Id = new SelectList(db.ContactHealthInfoes, "ContactId", "AllergiesToMedications", contact.Id);
//            ViewBag.Id = new SelectList(db.ContactIdentifications, "ContactId", "IdOrPassport", contact.Id);
//            ViewBag.Id = new SelectList(db.ContactWorkPreferences, "ContactId", "ExperienceOnWorkAreas", contact.Id);
//            return View(contact);
//        }

//        // POST: Contact/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Edit([Bind(Include = "Id,ContactName,Prefix,FirstName,LastName,Suffix,Gender,PositionAndCompany,NickName,Notes,HistoryWithTheCenter,FoodAllergies,Birthdate")] Contact contact)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(contact).State = EntityState.Modified;
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            ViewBag.Id = new SelectList(db.ContactDharmaExperiences, "ContactId", "FollowerOfReligionWhich", contact.Id);
//            ViewBag.Id = new SelectList(db.ContactDonorInfoes, "ContactId", "ContactId", contact.Id);
//            ViewBag.Id = new SelectList(db.ContactEducations, "ContactId", "DetailsOfUniversityPostGraduateOrTechnicalStudies", contact.Id);
//            ViewBag.Id = new SelectList(db.ContactHealthInfoes, "ContactId", "AllergiesToMedications", contact.Id);
//            ViewBag.Id = new SelectList(db.ContactIdentifications, "ContactId", "IdOrPassport", contact.Id);
//            ViewBag.Id = new SelectList(db.ContactWorkPreferences, "ContactId", "ExperienceOnWorkAreas", contact.Id);
//            return View(contact);
//        }

//        // GET: Contact/Delete/5
//        public async Task<ActionResult> Delete(Guid? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Contact contact = await db.contact.FindAsync(id);
//            if (contact == null)
//            {
//                return HttpNotFound();
//            }
//            return View(contact);
//        }

//        // POST: Contact/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> DeleteConfirmed(Guid id)
//        {
//            Contact contact = await db.contact.FindAsync(id);
//            db.contact.Remove(contact);
//            await db.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
