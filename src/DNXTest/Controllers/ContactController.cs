using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DNXTest.Controllers
{
    public class ContactController : Controller
    {

        private readonly ContactUnitOfWork      _contactUnitOfWork;
        private readonly ILogger                _logger;

        public ContactController(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _contactUnitOfWork = new ContactUnitOfWork(context,loggerFactory);
            _logger = loggerFactory.CreateLogger("ContactController");
        }


        // GET: /<controller>/
        public async Task<IActionResult>  Index()
        {
            try
            {
                Contact contact = new Contact();
                contact.Prefix = "";
                contact.InitIds();

                //_contactUnitOfWork.RepositoryContact.Insert(contact);

                //await _contactUnitOfWork.SaveAsync();

                return View(contact);
                //return View(await _contactUnitOfWork.RepositoryContact.GetAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name" , ex.Message), ex);
                return null;
            }
        }


        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(/*[Bind("ContactName,Prefix,FirstName,LastName,Suffix,Gender,PositionAndCompany,NickName,Notes,HistoryWithTheCenter,FoodAllergies,Birthdate")]*/ string contactJSON)
        {
            try
            {
                Contact contact = JsonConvert.DeserializeObject<Contact>(contactJSON);
                contact.InitIds();
                contact.LastChangeTimestamp = DateTime.Now;
                _contactUnitOfWork.RepositoryContact.Insert(contact);

                await _contactUnitOfWork.SaveAsync();
                    
                //ViewBag.Id = new SelectList(db.ContactDharmaExperiences, "ContactId", "FollowerOfReligionWhich", contact.Id);
                //ViewBag.Id = new SelectList(db.ContactDonorInfoes, "ContactId", "ContactId", contact.Id);
                //ViewBag.Id = new SelectList(db.ContactEducations, "ContactId", "DetailsOfUniversityPostGraduateOrTechnicalStudies", contact.Id);
                //ViewBag.Id = new SelectList(db.ContactHealthInfoes, "ContactId", "AllergiesToMedications", contact.Id);
                //ViewBag.Id = new SelectList(db.ContactIdentifications, "ContactId", "IdOrPassport", contact.Id);
                //ViewBag.Id = new SelectList(db.ContactWorkPreferences, "ContactId", "ExperienceOnWorkAreas", contact.Id);
                return View(contact);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                throw ex;
            }
        }

        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return RedirectToAction("Index"); 
        //    }

        //    Contact contact = RepoContact.GetByID(id);
        //    if (contact == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(contact);
        //}

        //// POST: Contacts/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind("Id,ContactName,Email,PhoneNr,Address")] Contact contact)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        RepoContact.Update(contact);
        //        RepoContact.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return View(contact);
        //}


        //// GET: Contacts/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    Contact contact = RepoContact.GetByID(id);
        //    if (contact == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(contact);
        //}


        //// GET: Contacts/Delete/5
        //public ActionResult Delete(Guid? Id)
        //{
        //    if (Id == null)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    Contact contact = RepoContact.GetByID(Id);
        //    if (contact == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(contact);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    Contact contact = RepoContact.GetByID(id);
        //    RepoContact.Delete(contact);
        //    RepoContact.Save();

        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contactUnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
