﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DNXTest.Models;
using DNXTest.Dal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace DNXTest.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactUnitOfWork      _contactUnitOfWork;
        private readonly ILogger                _logger;

        public ContactController(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _contactUnitOfWork = new ContactUnitOfWork(context, loggerFactory);
            _logger = loggerFactory.CreateLogger("ContactController");
        }

        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult>  Index(Guid? id)
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
        //[ValidateAntiForgeryToken] TODO
        public async Task<ActionResult> Create( string contactJSON)
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
                return Json( new { success = true, responseText = "Contact has been saved succesfully!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                return Json( new { success = false, responseText = "There was an error processing the request!" });
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
        public async Task< ActionResult> Delete(Guid? Id)
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
