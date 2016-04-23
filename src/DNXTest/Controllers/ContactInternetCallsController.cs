using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;

namespace DNXTest.Controllers
{
    public class ContactInternetCallsController : Controller
    {
       /* private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactInternetCalls
        public async Task<ActionResult> Index()
        {
            return View(await db.ContactInternetCalls.ToListAsync());
        }

        // GET: ContactInternetCalls/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInternetCall contactInternetCall = await db.ContactInternetCalls.FindAsync(id);
            if (contactInternetCall == null)
            {
                return HttpNotFound();
            }
            return View(contactInternetCall);
        }

        // GET: ContactInternetCalls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactInternetCalls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,InternetCallId,Description")] ContactInternetCall contactInternetCall)
        {
            if (ModelState.IsValid)
            {
                db.ContactInternetCalls.Add(contactInternetCall);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contactInternetCall);
        }

        // GET: ContactInternetCalls/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInternetCall contactInternetCall = await db.ContactInternetCalls.FindAsync(id);
            if (contactInternetCall == null)
            {
                return HttpNotFound();
            }
            return View(contactInternetCall);
        }

        // POST: ContactInternetCalls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id,InternetCallId,Description")] ContactInternetCall contactInternetCall)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactInternetCall).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contactInternetCall);
        }

        // GET: ContactInternetCalls/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInternetCall contactInternetCall = await db.ContactInternetCalls.FindAsync(id);
            if (contactInternetCall == null)
            {
                return HttpNotFound();
            }
            return View(contactInternetCall);
        }

        // POST: ContactInternetCalls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContactInternetCall contactInternetCall = await db.ContactInternetCalls.FindAsync(id);
            db.ContactInternetCalls.Remove(contactInternetCall);
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
