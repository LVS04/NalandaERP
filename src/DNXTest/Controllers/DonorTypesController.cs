using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;

namespace DNXTest.Controllers
{
    public class DonorTypesController : Controller
    {
        /*
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DonorTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.DonorTypes.ToListAsync());
        }

        // GET: DonorTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorType donorType = await db.DonorTypes.FindAsync(id);
            if (donorType == null)
            {
                return HttpNotFound();
            }
            return View(donorType);
        }

        // GET: DonorTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonorTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Description")] DonorType donorType)
        {
            if (ModelState.IsValid)
            {
                db.DonorTypes.Add(donorType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(donorType);
        }

        // GET: DonorTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorType donorType = await db.DonorTypes.FindAsync(id);
            if (donorType == null)
            {
                return HttpNotFound();
            }
            return View(donorType);
        }

        // POST: DonorTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id,Description")] DonorType donorType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donorType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(donorType);
        }

        // GET: DonorTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorType donorType = await db.DonorTypes.FindAsync(id);
            if (donorType == null)
            {
                return HttpNotFound();
            }
            return View(donorType);
        }

        // POST: DonorTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DonorType donorType = await db.DonorTypes.FindAsync(id);
            db.DonorTypes.Remove(donorType);
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
