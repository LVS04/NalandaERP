using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNet.Http.Internal;
using Microsoft.Extensions.Primitives;


namespace DNXTest.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactUnitOfWork _contactUnitOfWork;
        private readonly ILogger _logger;

        public ContactController(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _contactUnitOfWork = new ContactUnitOfWork(context, loggerFactory);
            _logger = loggerFactory.CreateLogger("ContactController");
        }

        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> Index(Guid? id)
        {
            try
            {
                Contact _contact = null;

                if (!(id == null))
                {
                    _contact = await _contactUnitOfWork.GetContactByIdAsync(id.Value);
                    ViewData["SaveOperation"] = "Save";
                }

                if (_contact == null)
                {
                    _contact = new Contact();
                    ViewData["SaveOperation"] = "Create";
                }
                return View(_contact);
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
        //[ValidateAntiForgeryToken] TODO
        public async Task<ActionResult> Create(string contactJSON)
        {
            try
            {
                Contact contact = JsonConvert.DeserializeObject<Contact>(contactJSON);
                contact.InitIds();

                //contact.ContactName = string.Format("{0} {1} {2} {3}" contact.Prefix
                contact.LastChangeTimestamp = DateTime.Now;
                _contactUnitOfWork.InsertContact(contact);

                await _contactUnitOfWork.SaveAsync();

                //  Success
                return Json(new { success = true, responseText = "Contact has been saved succesfully!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                return Json(new { success = false, responseText = "There was an error processing the request!" });
            }
        }


        [HttpPost]
        //[ValidateAntiForgeryToken] TODO
        public async Task<ActionResult> Update(string contactJSON, Guid id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                Contact contactToUpdate = await _contactUnitOfWork.GetContactByIdAsync(id);

                if (contactToUpdate == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    Contact contactNewData = JsonConvert.DeserializeObject<Contact>(contactJSON);
                    contactNewData.InitIds(id);

                    _contactUnitOfWork.ResetContactDependants(contactToUpdate);
                    contactToUpdate.CopyPropertiesFrom(contactNewData);
                    contactToUpdate.LastChangeTimestamp = DateTime.Now;
                    _contactUnitOfWork.UpdateContact(contactToUpdate);
                    await _contactUnitOfWork.SaveAsync();
                }

                //  Success
                return Json(new { success = true, responseText = "Contact has been Updated succesfully!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                return Json(new { success = false, responseText = "There was an error Updating the contact!" });
            }
        }


        // GET: Contacts/Delete/5
        public async Task<ActionResult> Delete(Guid? Id)
        {
            try
            {
                if (Id == null)
                {
                    return RedirectToAction("Index");
                }
                Contact Contact = await _contactUnitOfWork.GetContactByIdAsync(Id.Value);
                _contactUnitOfWork.DeleteContact(Contact);
                await _contactUnitOfWork.SaveAsync();
                return RedirectToAction("List");
            }

            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                throw ex;
            }

        }

        public ActionResult BloodHoundContacts()
        {
            try
            {
                return Json(_contactUnitOfWork.RepositoryContact.Get(orderBy: x => x.OrderBy(k => k.FirstName)).Take(500).Select(x => new { x.Id, x.ContactName }));
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                throw ex;
            }
        }
        public ActionResult BloodHoundRemote(string wildcard)
        {
            try
            {
                var results = _contactUnitOfWork.RepositoryContact.Get(filter: c => c.ContactName.Contains(wildcard)).Take(500);
                return Json(results.Select(x => new { x.Id, x.ContactName }));
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                throw ex;
            }
        }

        public ActionResult ListBase()
        {
            return View();
        }


        public async Task<IActionResult> ListBazzing(int current = 1, int rowCount = 15, string searchPhrase = null  )
        {
            try
            {
                int lines = rowCount;
                if (Request.Form.Keys.Count == 4)
                {
                    //  Sorted request
                    //  --------------
                    KeyValuePair<string,StringValues> sortof = (KeyValuePair<string, StringValues>)Request.Form.ToArray()[2];
                    string[]    fields = sortof.Key.Split('[');
                    string      field = fields[1].Replace("]", "");

                    var sortExpression = _contactUnitOfWork.RepositoryContact.GetSortExpression(field, sortof.Value);

                    if (searchPhrase != null)
                    {
                        //  Sorted request with where
                        //  -------------------------
                        var count = _contactUnitOfWork.RepositoryContact.CountRecords(c => c.ContactName.Contains(searchPhrase.ToLower()));

                        var results = _contactUnitOfWork.RepositoryContact.GetAsync
                        (
                            filter: c => c.ContactName.Contains(searchPhrase.ToLower()),
                            rowCount: lines,
                            currentPage: current,
                            totalRecords: count,
                            orderBy: sortExpression
                        ).Result.Select(x => new
                        {
                            x.ContactName,
                            x.Gender,
                            x.PositionAndCompany,
                            x.NickName,
                            x.Birthdate,
                            x.FoodAllergies
                        });

                        return Json(new
                        {
                            current = current,
                            rowCount = lines,
                            rows = results.ToArray(),
                            total = count
                        });

                    }
                    else
                    {
                        //  Sorted request withOUT where
                        //  -------------------------

                        var count = _contactUnitOfWork.RepositoryContact.CountRecords();

                        var results = _contactUnitOfWork.RepositoryContact.GetAsync
                        (
                            rowCount: lines,
                            currentPage: current,
                            totalRecords: count,
                            orderBy: sortExpression
                        ).Result.Select(x => new
                        {
                            x.ContactName,
                            x.Gender,
                            x.PositionAndCompany,
                            x.NickName,
                            x.Birthdate,
                            x.FoodAllergies
                        });

                        return Json(new
                        {
                            current = current,
                            rowCount = lines,
                            rows = results.ToArray(),
                            total = count
                        });
                    }
                }
                else
                {
                    //  Unsorted request
                    //  ----------------
                    if(searchPhrase == null)
                    {
                        var count = _contactUnitOfWork.RepositoryContact.CountRecords();

                        var results = _contactUnitOfWork.RepositoryContact.GetAsync
                        (
                            rowCount: lines,
                            currentPage: current,
                            totalRecords: count

                        ).Result.Select(x => new
                        {
                            x.ContactName,
                            x.Gender,
                            x.PositionAndCompany,
                            x.NickName,
                            x.Birthdate,
                            x.FoodAllergies
                        });

                        return Json(new
                        {
                            current = current,
                            rowCount = lines,
                            rows = results.ToArray(),
                            total = count
                        });
                    }
                    else
                    {
                        var count = _contactUnitOfWork.RepositoryContact.CountRecords(c => c.ContactName.Contains(searchPhrase.ToLower()));

                        var results = _contactUnitOfWork.RepositoryContact.GetAsync
                        (
                            filter: c => c.ContactName.Contains(searchPhrase.ToLower()),
                            rowCount: lines,
                            currentPage: current,
                            totalRecords: count
                        ).Result.Select(x => new
                        {
                            x.ContactName,
                            x.Gender,
                            x.PositionAndCompany,
                            x.NickName,
                            x.Birthdate,
                            x.FoodAllergies
                        });

                        return Json(new
                        {
                            current = current,
                            rowCount = lines,
                            rows = results.ToArray(),
                            total = count
                        });

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                throw ex;
            }
        }

        public async Task<IActionResult> List(string wildcard)
        {
            try
            {
                if (wildcard == null)
                    return View( await _contactUnitOfWork.RepositoryContact.GetAsync() ); 
                else
                    return View ( await _contactUnitOfWork.RepositoryContact.GetAsync(filter: c => c.ContactName.Contains(wildcard)));

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                throw ex;
            }
        }


        public ActionResult EmailExists(string Id)
        {
            try
            {
                string email = Request.Form["Emails[][Email]"];
                Guid contactId = new Guid(Id);
                var test = _contactUnitOfWork.RepositoryContactEmail.Get(e => e.Email.ToLower() == email.ToLower()).ToList();
                if (test.Count>0)
                {
                    //var get
                    var count = test.Where(c => c.ContactId != contactId).Count();
                    if (count > 0)
                        return Json("E-mail address already in use!");
                }
                  
                return Json("true");
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                throw ex;
            }
        }

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
