using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;

namespace DNXTest.Controllers
{
    public class DonorContextsController : Controller
    {
        /*
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DonorContexts
        public async Task<ActionResult> Index()
        {
            return View(await db.DonorContexts.ToListAsync());
        }

        // GET: DonorContexts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorContext DonorContext = await db.DonorContexts.FindAsync(id);
            if (DonorContext == null)
            {
                return HttpNotFound();
            }
            return View(DonorContext);
        }

        // GET: DonorContexts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonorContexts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Description")] DonorContext DonorContext)
        {
            if (ModelState.IsValid)
            {
                db.DonorContexts.Add(DonorContext);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(DonorContext);
        }

        // GET: DonorContexts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorContext DonorContext = await db.DonorContexts.FindAsync(id);
            if (DonorContext == null)
            {
                return HttpNotFound();
            }
            return View(DonorContext);
        }

        // POST: DonorContexts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id,Description")] DonorContext DonorContext)
        {
            if (ModelState.IsValid)
            {
                db.Entry(DonorContext).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(DonorContext);
        }

        // GET: DonorContexts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorContext DonorContext = await db.DonorContexts.FindAsync(id);
            if (DonorContext == null)
            {
                return HttpNotFound();
            }
            return View(DonorContext);
        }

        // POST: DonorContexts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DonorContext DonorContext = await db.DonorContexts.FindAsync(id);
            db.DonorContexts.Remove(DonorContext);
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
