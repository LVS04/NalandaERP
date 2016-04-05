using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DNXTest.Controllers
{
    public class ContactController : Controller
    {


        private readonly GenericRepository<Contact> RepoContact;
        private readonly ApplicationDbContext db;

        public ContactController(ApplicationDbContext context )
        {
            RepoContact = new GenericRepository<Contact>(context);
            db = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(RepoContact.Get().ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ContactName,Email,PhoneNr,Address")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                RepoContact.Insert(contact);
                RepoContact.Save();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index"); 
            }

            Contact contact = RepoContact.GetByID(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,ContactName,Email,PhoneNr,Address")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                RepoContact.Update(contact);
                RepoContact.Save();
                return RedirectToAction("Index");
            }
            return View(contact);
        }


        // GET: Contacts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Contact contact = RepoContact.GetByID(id);
            if (contact == null)
            {
                return RedirectToAction("Index");
            }
            return View(contact);
        }


        // GET: Contacts/Delete/5
        public ActionResult Delete(Guid? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index");
            }

            Contact contact = RepoContact.GetByID(Id);
            if (contact == null)
            {
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Contact contact = RepoContact.GetByID(id);
            RepoContact.Delete(contact);
            RepoContact.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
