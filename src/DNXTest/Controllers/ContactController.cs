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
        public async Task<IActionResult>  Index(Guid? id)
        {
            try
            {
                Contact _contact;

                if (id == null)
                    _contact = new Contact();
                else
                    _contact = await _contactUnitOfWork.RepositoryContact.GetByIDAsync(id);

                return View(_contact);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name" , ex.Message), ex);
                throw ex;
            }
        }

        public async Task<IActionResult> List()
        {
            try
            {
                return View(await _contactUnitOfWork.RepositoryContact.GetAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                throw ex;
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

                //contact.ContactName = string.Format("{0} {1} {2} {3}" contact.Prefix
                contact.LastChangeTimestamp = DateTime.Now;
                _contactUnitOfWork.RepositoryContact.Insert(contact);

                await _contactUnitOfWork.SaveAsync();

                return View("List");
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                throw ex;
            }
        }


        //public async Task<ActionResult> Edit(Guid? id)
        //{
        //    try
        //    {
        //        if (id == null)
        //        {
        //            return RedirectToAction("Index");
        //        }

        //        Contact contact = await _contactUnitOfWork.RepositoryContact.GetByIDAsync(id);
        //        if (contact == null)
        //        {
        //            return HttpNotFound();
        //        }

        //        return RedirectToAction("Index",  contact); 
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
        //        throw ex;
        //    }
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


        // GET: Contacts/Delete/5
        public ActionResult Delete(Guid? Id)
        {
            try
            {
                if (Id == null)
                {
                    return RedirectToAction("Index");
                }


                //  Cascade delete still not available in EF7!!!
                try
                {
                    var phones = _contactUnitOfWork.RepositoryContactPhone.Get().Where(x => x.Contact.Id == Id).ToList();
                    foreach (var phone in phones) _contactUnitOfWork.RepositoryContactPhone.Delete(phone);
                }
                catch { }
                try
                {
                    var emails = _contactUnitOfWork.RepositoryContactEmail.Get().Where(x => x.Contact.Id == Id).ToList();
                    foreach (var email in emails) _contactUnitOfWork.RepositoryContactEmail.Delete(email);
                }
                catch { }
                try
                {
                    var websites = _contactUnitOfWork.RepositoryContactWebsite.Get().Where(x => x.Contact.Id == Id).ToList();
                    foreach (var website in websites) _contactUnitOfWork.RepositoryContactEmail.Delete(website);
                }
                catch { }
                try
                {
                    var addresses = _contactUnitOfWork.RepositoryContactAddress.Get().Where(x => x.Contact.Id == Id).ToList();
                    foreach (var address in addresses) _contactUnitOfWork.RepositoryContactEmail.Delete(address);
                }
                catch { }
                try
                {
                    var dates = _contactUnitOfWork.RepositoryContactDate.Get().Where(x => x.Contact.Id == Id).ToList();
                    foreach (var date in dates) _contactUnitOfWork.RepositoryContactEmail.Delete(date);
                }
                catch { }
                try
                {
                    var relateds = _contactUnitOfWork.RepositoryContactRelated.Get().Where(x => x.Contact.Id == Id).ToList();
                    foreach (var related in relateds) _contactUnitOfWork.RepositoryContactEmail.Delete(related);
                }
                catch { }
                try
                {
                    var ims = _contactUnitOfWork.RepositoryContactIM.Get().Where(x => x.Contact.Id == Id).ToList();
                    foreach (var im in ims) _contactUnitOfWork.RepositoryContactEmail.Delete(im);
                }
                catch { }
                try
                {
                    var intcalls = _contactUnitOfWork.RepositoryContactInternetCall.Get().Where(x => x.Contact.Id == Id).ToList();
                    foreach (var intcall in intcalls) _contactUnitOfWork.RepositoryContactEmail.Delete(intcall);
                }
                catch { }

                _contactUnitOfWork.RepositoryContact.Delete(Id);

                _contactUnitOfWork.Save();
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                throw ex;
            }
        }

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
