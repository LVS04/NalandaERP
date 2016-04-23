using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;

namespace DNXTest.Controllers
{
    public class DonorInterestsController : Controller
    {
        /*
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DonorInterests
        public async Task<ActionResult> Index()
        {
            return View(await db.DonorInterests.ToListAsync());
        }

        // GET: DonorInterests/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorInterest donorInterest = await db.DonorInterests.FindAsync(id);
            if (donorInterest == null)
            {
                return HttpNotFound();
            }
            return View(donorInterest);
        }

        // GET: DonorInterests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonorInterests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Description")] DonorInterest donorInterest)
        {
            if (ModelState.IsValid)
            {
                db.DonorInterests.Add(donorInterest);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(donorInterest);
        }

        // GET: DonorInterests/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorInterest donorInterest = await db.DonorInterests.FindAsync(id);
            if (donorInterest == null)
            {
                return HttpNotFound();
            }
            return View(donorInterest);
        }

        // POST: DonorInterests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id,Description")] DonorInterest donorInterest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donorInterest).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(donorInterest);
        }

        // GET: DonorInterests/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorInterest donorInterest = await db.DonorInterests.FindAsync(id);
            if (donorInterest == null)
            {
                return HttpNotFound();
            }
            return View(donorInterest);
        }

        // POST: DonorInterests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DonorInterest donorInterest = await db.DonorInterests.FindAsync(id);
            db.DonorInterests.Remove(donorInterest);
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
