using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;

namespace DNXTest.Controllers
{
    public class ContactIdentificationsController : Controller
    {
        
        //private ApplicationDbContext db = new ApplicationDbContext();

        //// GET: ContactIdentifications
        //public async Task<ActionResult> Index()
        //{
        //    var contactIdentifications = db.ContactIdentifications.Include(c => c.Contact);
        //    return View(await contactIdentifications.ToListAsync());
        //}

        //// GET: ContactIdentifications/Details/5
        //public async Task<ActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ContactIdentification contactIdentification = await db.ContactIdentifications.FindAsync(id);
        //    if (contactIdentification == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(contactIdentification);
        //}

        //// GET: ContactIdentifications/Create
        //public ActionResult Create()
        //{
        //    ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName");
        //    return View();
        //}

        //// POST: ContactIdentifications/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind("ContactId,IdOrPassport,IdOrPassportIssueDate,IdOrPassportExpiryDate,FiscalId")] ContactIdentification contactIdentification)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        contactIdentification.ContactId = Guid.NewGuid();
        //        db.ContactIdentifications.Add(contactIdentification);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName", contactIdentification.ContactId);
        //    return View(contactIdentification);
        //}

        //// GET: ContactIdentifications/Edit/5
        //public async Task<ActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ContactIdentification contactIdentification = await db.ContactIdentifications.FindAsync(id);
        //    if (contactIdentification == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName", contactIdentification.ContactId);
        //    return View(contactIdentification);
        //}

        //// POST: ContactIdentifications/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind("ContactId,IdOrPassport,IdOrPassportIssueDate,IdOrPassportExpiryDate,FiscalId")] ContactIdentification contactIdentification)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(contactIdentification).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ContactId = new SelectList(db.contact, "Id", "ContactName", contactIdentification.ContactId);
        //    return View(contactIdentification);
        //}

        //// GET: ContactIdentifications/Delete/5
        //public async Task<ActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ContactIdentification contactIdentification = await db.ContactIdentifications.FindAsync(id);
        //    if (contactIdentification == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(contactIdentification);
        //}

        //// POST: ContactIdentifications/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(Guid id)
        //{
        //    ContactIdentification contactIdentification = await db.ContactIdentifications.FindAsync(id);
        //    db.ContactIdentifications.Remove(contactIdentification);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
