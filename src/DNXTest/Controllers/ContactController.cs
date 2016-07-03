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
using DNXTest.Helpers;


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

        [HttpGet]
        public async Task<IActionResult> DetailPartial(Guid id)
        {
            try
            {
                Contact _contact = null;

                if (!(id == null))
                {
                    _contact = await _contactUnitOfWork.GetContactByIdAsync(id);
                    ViewData["SaveOperation"] = "Save";
                }

                if (_contact == null)
                {
                    _contact = new Contact();
                    ViewData["SaveOperation"] = "Create";
                }
                return PartialView("Index",_contact);
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
                return RedirectToAction("ListBase");
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
                if(wildcard != null) wildcard = wildcard.Trim();

                var count = _contactUnitOfWork.RepositoryContact.CountRecords(c => c.ContactName.Contains(wildcard.ToLower()));

                var results = _contactUnitOfWork.RepositoryContact.GetAsync(filter: c => c.ContactName.Contains(wildcard),rowCount:15,totalRecords: count).Result;

                var resultsArray = results.Select(x => new { x.Id, x.ContactName });

                return Json(new
                {
                    rows = resultsArray,
                    total = count
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                throw ex;
            }
        }

        public ActionResult ListBase(string wildcard = "")
        {
            
            ViewData["InItSeArCh"] = wildcard;
            return View();
        }

        public ActionResult ListBazzing(int current = 1, int rowCount = 15, string searchPhrase = null, string[] values=null, Dictionary<string,string> data = null )
        {
            try
            {
                if (values.Count() > 0 )
                {
                    if (values[0] == null) values[0] = string.Empty;
                    if (_contactUnitOfWork.AreValidParams(values, data["columns"], data["tableKeys"], data["operators"], data["tables"]))
                    {

                        string countQuery = _contactUnitOfWork.BuildQuery(values, data["columns"], data["tableKeys"], data["operators"], data["tables"], rowCount, count:true);
                        int count = _contactUnitOfWork.RunCountQuery(countQuery);

                        string query = _contactUnitOfWork.BuildQuery(values, data["columns"], data["tableKeys"], data["operators"], data["tables"],rowCount, skip:(current-1)*rowCount);
                        var results = _contactUnitOfWork.RunQuery(query);

                        return Json(new
                        {
                            current = current,
                            rowCount = rowCount,
                            rows = results.ToArray(),
                            total = count
                        });
                    }
                }

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
                            Birthdate = (x.Birthdate.HasValue)?  x.Birthdate.Value.ToString("yyyy-MM-dd"):null,
                            x.FoodAllergies,
                            detail = WebHelpers.CreateLink(Url, "Contact", "Index", "details", x.Id, onClick: "if(typeof advancedSearch !== 'undefined'){fillSearchDetails(this.href);return false;}"),
                            delete = WebHelpers.CreateLink(Url, "Contact", "Delete", "delete",x.Id, "text-danger", "$(\'#linkConfirm\').attr(\'href\', this.href);$('#ModalMessage').text('Do you confirm the contact deletion?');$(\'#ModalConfirm\').modal(\'show\');return false;")
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
                            Birthdate = (x.Birthdate.HasValue) ? x.Birthdate.Value.ToString("yyyy-MM-dd") : null,
                            x.FoodAllergies,
                            detail = WebHelpers.CreateLink(Url, "Contact", "Index", "details", x.Id, onClick: "if(typeof advancedSearch !== 'undefined'){fillSearchDetails(this.href);return false;}"),
                            delete = WebHelpers.CreateLink(Url, "Contact", "Delete", "delete", x.Id, "text-danger", "$(\'#linkConfirm\').attr(\'href\', this.href);$('#ModalMessage').text('Do you confirm the contact deletion?');$(\'#ModalConfirm\').modal(\'show\');return false;")
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
                            Birthdate = (x.Birthdate.HasValue) ? x.Birthdate.Value.ToString("yyyy-MM-dd") : null,
                            x.FoodAllergies,
                            detail = WebHelpers.CreateLink(Url, "Contact", "Index", "details", x.Id, onClick: "if(typeof advancedSearch !== 'undefined'){fillSearchDetails(this.href);return false;}"),
                            delete = WebHelpers.CreateLink(Url, "Contact", "Delete", "delete", x.Id, "text-danger", "$(\'#linkConfirm\').attr(\'href\', this.href);$('#ModalMessage').text('Do you confirm the contact deletion?');$(\'#ModalConfirm\').modal(\'show\');return false;")

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
                            Birthdate = (x.Birthdate.HasValue) ? x.Birthdate.Value.ToString("yyyy-MM-dd") : null,
                            x.FoodAllergies,
                            detail = WebHelpers.CreateLink(Url, "Contact", "Index", "details", x.Id, onClick: "if(typeof advancedSearch !== 'undefined'){fillSearchDetails(this.href);return false;}"),
                            delete = WebHelpers.CreateLink(Url, "Contact", "Delete", "delete", x.Id, "text-danger", "$(\'#linkConfirm\').attr(\'href\', this.href);$('#ModalMessage').text('Do you confirm the contact deletion?');$(\'#ModalConfirm\').modal(\'show\');return false;")
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

        public ActionResult AdvancedSearch()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                throw ex;
            }
        }

        public ActionResult AdvancedSearchQuery(string[] values, string columns, string tableKeys, string operators, string tables)
        {
            try
            {
                if (_contactUnitOfWork.AreValidParams( values, columns, tableKeys, operators, tables))
                {
                    //string query = _contactUnitOfWork.BuildQuery(values, columns, tableKeys, operators, tables);

                    string results = string.Format(@"<table id='grid-data-api' class='table table-condensed table-hover table-striped' data-toggle='bootgrid' data-ajax='true' data-url='{0}' >
                        <thead>
                            <tr>
                                <th data-column-id='Id' data-sortable='false' data-visible='false' >Id</th>
                                <th data-column-id='ContactName' data-sortable='false'>Contact Name</th>
                                {1}
                                <th data-column-id='detail' data-sortable='false' data-align='center' data-header-align='center' data-formatter='link'>DETAILS</th>
                            </tr>
                        </thead>
                    </table>
                    ", Url.Action("ListBazzing","Contact"), WebHelpers.CreateTable(columns));

                    return Json(new { status = "success" , message = string.Empty, results = results });
                }
                else return null;
                    /*
                    if ($group_id == 0) {
                        echo json_encode(array(
                            'status' => 'error',
                            'message'=> 'error message'
                        ));
                        }
                        else
                        {
                        echo json_encode(array(
                            'status' => 'success',
                            'message'=> 'success message'
                        ));
                        }
                    */
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                throw ex;
            }
        }

        public ActionResult AdvancedSearchGetTree()
        {
            return Json(new
            {
                zeze = "var tables = '';var tableKeys = '';var tablesKeysArray = '';var fields = '';var valuesArray = '';var columns = '';var columsArray = '';var operators = '';var operatorsArray = '';var query = '';"
            ,
                gettadata = new object[]
            {
                new {
                    text="Prefix",
                    dataType= "string",
                    targetObject= "\"Contact\".\"Prefix\"",
                    sourceInput= "#ContactPrefix"
                },
                new {
                    text="First name",
                    dataType= "string",
                    targetObject= "\"Contact\".\"FirstName\"",
                    sourceInput= "#ContactFirstName"
                },
                new {
                    text="Last name",
                    dataType= "string",
                    targetObject= "\"Contact\".\"LastName\"",
                    sourceInput= "#ContactLastName"
                },
                new {
                    text="Suffix",
                    dataType= "string",
                    targetObject= "\"Contact\".\"Suffix\"",
                    sourceInput= "#ContactSuffix"
                },
                new {
                    text="Gender",
                    dataType= "comboGender",
                    targetObject= "\"Contact\".\"Gender\"",
                    sourceInput= "#ContactGender"
                },
                new {
                    text="Birthdate",
                    dataType= "date",
                    targetObject= "\"Contact\".\"Birthdate\"",
                    sourceInput= "#ContactBirthdate"
                },
                new {
                    text="Position and company",
                    dataType= "string",
                    targetObject= "\"Contact\".\"PositionAndCompany\"",
                    sourceInput= "#ContactPositionAndCompany"
                },
                new {
                    text="Nickname",
                    dataType= "string",
                    targetObject= "\"Contact\".\"NickName\"",
                    sourceInput= "#ContactNickName"
                },
                new {
                    text="Notes",
                    dataType= "string",
                    targetObject= "\"Contact\".\"Notes\"",
                    sourceInput= "#ContactNotes"
                },
                new {
                    text="History with the center",
                    dataType= "string",
                    targetObject= "\"Contact\".\"HistoryWithTheCenter",
                    sourceInput= "#ContactHistoryWithTheCenter"
                },
                new {
                    text="Food allergies",
                    dataType= "string",
                    targetObject= "\"Contact\".\"FoodAllergies\"",
                    sourceInput= "#ContactFoodAllergies"
                },
                new {
                    text="Addresses",
                    dataType= "table",
                    tableKey= ".\"ContactId\"",
                    targetObject= "\"ContactAddress\"",
                    sourceInput= "#ContactAddress",
                    nodes = new []
                    {
                        new {
                            text="Street",
                            dataType= "string",
                            targetObject= "\"ContactAddress\".\"Street\"",
                            sourceInput= "#ContactAddressStreet"
                        },
                        new {
                            text="POBOX",
                            dataType= "string",
                            targetObject= "\"ContactAddress\".\"POBOX\"",
                            sourceInput= "#ContactAddressPOBOX"
                        },
                        new {
                            text="Neighborhood",
                            dataType= "string",
                            targetObject= "\"ContactAddress\".\"Neighborhood\"",
                            sourceInput= "#ContactAddressNeighborhood"
                        },
                        new {
                            text="City",
                            dataType= "string",
                            targetObject= "\"ContactAddress\".\"City\"",
                            sourceInput= "#ContactAddressCity"
                        },
                        new {
                            text="Province",
                            dataType= "string",
                            targetObject= "\"ContactAddress\".\"Province\"",
                            sourceInput= "#ContactAddressProvince"
                        },
                        new {
                            text="Postal code",
                            dataType= "string",
                            targetObject= "\"ContactAddress\".\"PostalCode\"",
                            sourceInput= "#ContactAddressPostalCode"
                        },
                        new {
                            text="Country",
                            dataType= "comboCountry",
                            targetObject= "\"ContactAddress\".\"Country\"",
                            sourceInput= "#ContactAddressCountry"
                        }
                    }
                },
                new {
                    text="Phones",
                    dataType= "table",
                    tableKey= ".\"ContactId\"",
                    targetObject= "\"ContactPhone\"",
                    nodes=
                    new [] {
                        new {
                            text="Number",
                            dataType= "string:numbers",
                            targetObject= "\"ContactPhone\".\"Number\"",
                            sourceInput= "#ContactPhoneNumber"
                        },
                        new {
                            text="Description",
                            dataType= "string",
                            targetObject= "\"ContactPhone\".\"Description\"",
                            sourceInput= "#ContactPhoneDescription"
                        }
                    }
                },
                new {
                    text="Emails",
                    dataType= "table",
                    tableKey= ".\"ContactId\"",
                    targetObject= "\"ContactEmail\"",
                    nodes=
                    new []{
                        new {
                            text="Email",
                            dataType= "string:email",
                            targetObject= "\"ContactEmail\".\"Email\"",
                            sourceInput= "#ContactEmailEmail"
                        },
                        new {
                            text="Description",
                            dataType= "string",
                            targetObject= "\"ContactEmail\".\"Description\"",
                            sourceInput= "#ContactEmailDescription"
                        }
                    }
                },
                new {
                    text="Websites",
                    dataType= "table",
                    tableKey= ".\"ContactId\"",
                    targetObject= "\"ContactWebsite\"",
                    nodes=
                    new [] {
                        new {
                            text="Website",
                            dataType= "string:website",
                            targetObject= "\"ContactWebsite\".\"WebSite\"",
                            sourceInput= "#ContactWebsiteWebSite"
                        },
                        new {
                            text="Description",
                            dataType= "string",
                            targetObject= "\"ContactWebsite\".\"Description\"",
                            sourceInput= "#ContactWebsiteDescription"
                        }
                    }
                },
                new {
                    text="Identification",
                    dataType= "table",
                    tableKey= ".\"Id\"",
                    targetObject= "\"ContactIdentification\"",
                    nodes =
                    new  []{
                        new {
                            text="Id or passport",
                            dataType= "string",
                            targetObject= "\"ContactIdentification\".\"IdOrPassport\"",
                            sourceInput= "#ContactIdentificationIdOrPassport"
                        },
                        new {
                            text="Id or passport issue date",
                            dataType= "date",
                            targetObject= "\"ContactIdentification\".\"IdOrPassportIssueDate\"",
                            sourceInput= "#ContactIdentificationIdOrPassportIssueDate"
                        },
                        new {
                            text="Id or passport expiry date",
                            dataType= "date",
                            targetObject= "\"ContactIdentification\".\"IdOrPassportExpiryDate\"",
                            sourceInput= "#ContactIdentificationIdOrPassportExpiryDate"
                        },
                        new {
                            text="Fiscal Id",
                            dataType= "string",
                            targetObject= "\"ContactIdentification\".\"FiscalId\"",
                            sourceInput= "#ContactIdentificationFiscalId"
                        },
                        new {
                            text="Born in country",
                            dataType= "comboCountry",
                            targetObject= "\"ContactIdentification\".\"BornInCountry\"",
                            sourceInput= "#ContactIdentificationBornInCountry"
                        },
                        new {
                            text="Spoken languages",
                            dataType= "comboSpokenLanguages",
                            targetObject= "\"ContactIdentification\".\"SpokenLanguages\"",
                            sourceInput= "#ContactIdentificationSpokenLanguages"
                        }
                    }
                },
                new {
                    text="Donor Info",
                    dataType= "table",
                    tableKey= ".\"Id\"",
                    targetObject= "\"ContactDonorInfo\"",
                    nodes=
                    new  [] {
                        new {
                            text="Donor religious situation",
                            dataType= "ComboReligiousSituation",
                            targetObject= "\"ContactDonorInfo\".\"DonorReligiousSituationId\"",
                            sourceInput= "#ContactDonorInfoDonorReligiousSituationId"
                        },
                        new {
                            text="Donor type",
                            dataType= "comboDonorType",
                            targetObject= "\"ContactDonorInfo\".\"DonorTypeId\"",
                            sourceInput= "#ContactDonorInfoDonorTypeId"
                        },
                        new {
                            text="Donor contexts",
                            dataType= "comboDonorContexts",
                            targetObject= "\"ContactDonorInfo\".\"DonorContexts\"",
                            sourceInput= "#ContactDonorInfoDonorContexts"
                        },
                        new {
                            text="Donor interests",
                            dataType= "comboDonorInterests",
                            targetObject= "\"ContactDonorInfo\".\"DonorInterests\"",
                            sourceInput= "#ContactDonorInfoDonorInterests"
                        }
                    }
                },
                new {
                    text="HealthInfo",
                    dataType= "table",
                    tableKey= ".\"Id\"",
                    targetObject= "\"ContactHealthInfo\"",
                    nodes= new []{
                        new {
                            text="Emergency contact 1 name",
                            dataType= "string",
                            targetObject= "\"ContactHealthInfo\".\"EmergencyContact1Name\"",
                            sourceInput= "#ContactHealthInfoEmergencyContact1Name"

                        },
                        new {
                            text="Emergency contact1 relationship",
                            dataType= "comboContactRelationship",
                            targetObject= "\"ContactHealthInfo\".\"EmergencyContact1Id\"",
                            sourceInput= "#ContactHealthInfoEmergencyContact1Id"
                        },
                        new {
                            text="Emergency contact 2 name",
                            dataType= "string",
                            targetObject= "\"ContactHealthInfo\".\"EmergencyContact2Name\"",
                            sourceInput= "#ContactHealthInfoEmergencyContact2Name"
                        },
                        new {
                            text="Emergency contact2 relationship",
                            dataType= "comboContactRelationship",
                            targetObject= "\"ContactHealthInfo\".\"EmergencyContact2RelationshipId\"",
                            sourceInput= "#ContactHealthInfoEmergencyContact2RelationshipId"
                        },
                        new {
                            text="Health insurance provider",
                            dataType= "string",
                            targetObject= "\"ContactHealthInfo\".\"HealthInsuranceProvider\"",
                            sourceInput= "#ContactHealthInfoHealthInsuranceProvider"
                        },
                        new {
                            text="Health insurance policy nr",
                            dataType= "string",
                            targetObject= "\"ContactHealthInfo\".\"HealthInsurancePolicyNr\"",
                            sourceInput= "#ContactHealthInfoHealthInsurancePolicyNr"
                        },
                        new {
                            text="Allergies to medications",
                            dataType= "string",
                            targetObject= "\"ContactHealthInfo\".\"AllergiesToMedications\"",
                            sourceInput= "#ContactHealthInfoAllergiesToMedications"
                        },
                        new {
                            text="Details to inform emergency services",
                            dataType= "string",
                            targetObject= "\"ContactHealthInfo\".\"DetailsToInformEmergencyServices\"",
                            sourceInput= "#ContactHealthInfoDetailsToInformEmergencyServices"
                        }
                    }
                }
            }
            });
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
