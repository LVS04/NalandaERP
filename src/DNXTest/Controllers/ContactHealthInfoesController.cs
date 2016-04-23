using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;

namespace DNXTest.Controllers
{
    public class ContactHealthInfoesController : Controller
    {
        /*
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactHealthInfoes
        public async Task<ActionResult> Index()
        {
            var contactHealthInfoes = db.ContactHealthInfoes.Include(c => c.Contact);
            return View(await contactHealthInfoes.ToListAsync());
        }

        // GET: ContactHealthInfoes/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactHealthInfo contactHealthInfo = await db.ContactHealthInfoes.FindAsync(id);
            if (contactHealthInfo == null)
            {
                return HttpNotFound();
            }
            return View(contactHealthInfo);
        }

        // GET: ContactHealthInfoes/Create
        public ActionResult Create()
        {
            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName");
            return View();
        }

        // POST: ContactHealthInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("ContactId,AllergiesToMedications,HealthInsuranceProvider,HealthInsurancePolicyNr,DetailsToInformEmergencyServices,PrescribedMedicationInLast4MonthsAndReasons,PsychologicalOrSeriousPhysicalConditionsTreatmentInTheLast2Years,MedicalConditionsToConsiderInEventOfEmergency,RestrictivePhysicalProblems")] ContactHealthInfo contactHealthInfo)
        {
            if (ModelState.IsValid)
            {
                contactHealthInfo.ContactId = Guid.NewGuid();
                db.ContactHealthInfoes.Add(contactHealthInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName", contactHealthInfo.ContactId);
            return View(contactHealthInfo);
        }

        // GET: ContactHealthInfoes/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactHealthInfo contactHealthInfo = await db.ContactHealthInfoes.FindAsync(id);
            if (contactHealthInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName", contactHealthInfo.ContactId);
            return View(contactHealthInfo);
        }

        // POST: ContactHealthInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("ContactId,AllergiesToMedications,HealthInsuranceProvider,HealthInsurancePolicyNr,DetailsToInformEmergencyServices,PrescribedMedicationInLast4MonthsAndReasons,PsychologicalOrSeriousPhysicalConditionsTreatmentInTheLast2Years,MedicalConditionsToConsiderInEventOfEmergency,RestrictivePhysicalProblems")] ContactHealthInfo contactHealthInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactHealthInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName", contactHealthInfo.ContactId);
            return View(contactHealthInfo);
        }

        // GET: ContactHealthInfoes/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactHealthInfo contactHealthInfo = await db.ContactHealthInfoes.FindAsync(id);
            if (contactHealthInfo == null)
            {
                return HttpNotFound();
            }
            return View(contactHealthInfo);
        }

        // POST: ContactHealthInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ContactHealthInfo contactHealthInfo = await db.ContactHealthInfoes.FindAsync(id);
            db.ContactHealthInfoes.Remove(contactHealthInfo);
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
