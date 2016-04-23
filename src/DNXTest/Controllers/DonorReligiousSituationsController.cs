using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;

namespace DNXTest.Controllers
{
    public class DonorReligiousSituationsController : Controller
    {
        /*
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DonorReligiousSituations
        public async Task<ActionResult> Index()
        {
            return View(await db.DonorReligiousSituations.ToListAsync());
        }

        // GET: DonorReligiousSituations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorReligiousSituation donorReligiousSituation = await db.DonorReligiousSituations.FindAsync(id);
            if (donorReligiousSituation == null)
            {
                return HttpNotFound();
            }
            return View(donorReligiousSituation);
        }

        // GET: DonorReligiousSituations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonorReligiousSituations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Description")] DonorReligiousSituation donorReligiousSituation)
        {
            if (ModelState.IsValid)
            {
                db.DonorReligiousSituations.Add(donorReligiousSituation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(donorReligiousSituation);
        }

        // GET: DonorReligiousSituations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorReligiousSituation donorReligiousSituation = await db.DonorReligiousSituations.FindAsync(id);
            if (donorReligiousSituation == null)
            {
                return HttpNotFound();
            }
            return View(donorReligiousSituation);
        }

        // POST: DonorReligiousSituations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id,Description")] DonorReligiousSituation donorReligiousSituation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donorReligiousSituation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(donorReligiousSituation);
        }

        // GET: DonorReligiousSituations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorReligiousSituation donorReligiousSituation = await db.DonorReligiousSituations.FindAsync(id);
            if (donorReligiousSituation == null)
            {
                return HttpNotFound();
            }
            return View(donorReligiousSituation);
        }

        // POST: DonorReligiousSituations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DonorReligiousSituation donorReligiousSituation = await db.DonorReligiousSituations.FindAsync(id);
            db.DonorReligiousSituations.Remove(donorReligiousSituation);
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
