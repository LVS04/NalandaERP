﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNXTest.Models;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Query;
using Microsoft.Data.Entity.Extensions;
using System.Text;


namespace DNXTest.Dal
{
    public class ContactUnitOfWork : IDisposable
    {
        private ApplicationDbContext _context;

        private readonly ILogger _logger;


        private GenericRepository<Contact>                          _repoContact;

        private GenericRepository<ContactEmail>                     _repoContactEmail;
        private GenericRepository<ContactPhone>                     _repoContactPhone;
        private GenericRepository<ContactRelated>                   _repoContactRelated;
        private GenericRepository<ContactAddress>                   _repoContactAddress;
        private GenericRepository<ContactDate>                      _repoContactDate;
        private GenericRepository<ContactWebsite>                   _repoContactWebsite;
        private GenericRepository<ContactInstantMessaging>          _repoContactIM;
        private GenericRepository<ContactInternetCall>              _repoContactInternetCall;

        private GenericRepository<ContactIdentification>            _repoContactIdentification;
        private GenericRepository<ContactDharmaExperience>          _repoContactDharmaExperience;
        private GenericRepository<ContactEducation>                 _repoContactEducation;
        private GenericRepository<ContactWorkPreference>            _repoContactWorkPreference;
        private GenericRepository<ContactVolunteeringExperience>    _repoContactVolunteeringExperience;
        private GenericRepository<ContactDonorInfo>                 _repoContactDonorInfo;
        private GenericRepository<ContactHealthInfo>                _repoContactHealthInfo;


        public ContactUnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("LoggerUnitOfWork");
        }

        public async Task<Contact> GetContactByIdAsync(Guid id)
        {
            try
            {

                Contact _contact;

                _contact = await RepositoryContact.GetByIDAsync(id);

                if (_contact != null)
                {
                    _contact.Addresses          = (ICollection<ContactAddress>)RepositoryContactAddress.GetAsync(a => a.Contact.Id == id, x=> x.OrderBy(k=>k.SortOrder)).Result;
                    _contact.Dates              = (ICollection<ContactDate>)RepositoryContactDate.GetAsync(a => a.Contact.Id == id, x => x.OrderBy(k => k.SortOrder)).Result;
                    _contact.Phones             = (ICollection<ContactPhone>)RepositoryContactPhone.GetAsync(a => a.Contact.Id == id, x => x.OrderBy(k => k.SortOrder)).Result;
                    _contact.RelatedContacts    = (ICollection<ContactRelated>)RepositoryContactRelated.GetAsync(a => a.Contact.Id == id, x => x.OrderBy(k => k.SortOrder)).Result;
                    _contact.Emails             = (ICollection<ContactEmail>)RepositoryContactEmail.GetAsync(a => a.Contact.Id == id, x => x.OrderBy(k => k.SortOrder)).Result;
                    _contact.WebSites           = (ICollection<ContactWebsite>)RepositoryContactWebsite.GetAsync(a => a.Contact.Id == id, x => x.OrderBy(k => k.SortOrder)).Result;
                    _contact.IMs                = (ICollection<ContactInstantMessaging>)RepositoryContactIM.GetAsync(a => a.Contact.Id == id, x => x.OrderBy(k => k.SortOrder)).Result;
                    _contact.InternetCallIds    = (ICollection<ContactInternetCall>)RepositoryContactInternetCall.GetAsync(a => a.Contact.Id == id, x => x.OrderBy(k => k.SortOrder)).Result;

                    _contact.ContactIdentification          = (ContactIdentification)RepositoryContactIdentification.GetAsync(a => a.Contact.Id == id).Result.FirstOrDefault();
                    _contact.ContactDharmaExperience        = (ContactDharmaExperience)RepositoryContactDharmaExperience.GetAsync(a => a.Contact.Id == id).Result.FirstOrDefault();
                    _contact.ContactEducation               = (ContactEducation)RepositoryContactEducation.GetAsync(a => a.Contact.Id == id).Result.FirstOrDefault();
                    _contact.ContactWorkPreference          = (ContactWorkPreference)RepositoryContactWorkPreference.GetAsync(a => a.Contact.Id == id).Result.FirstOrDefault();
                    _contact.ContactVolunteeringExperience  = (ContactVolunteeringExperience)RepositoryContactVolunteeringExperience.GetAsync(a => a.Contact.Id == id).Result.FirstOrDefault();
                    _contact.ContactDonorInfo               = (ContactDonorInfo)RepositoryContactDonorInfo.GetAsync(a => a.Contact.Id == id).Result.FirstOrDefault();
                    _contact.ContactHealthInfo              = (ContactHealthInfo)RepositoryContactHealthInfo.GetAsync(a => a.Contact.Id == id).Result.FirstOrDefault();
                }

                return _contact;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                throw ex;
            }

        }

        public void ResetContactDependants(Contact contact)
        {

            RepositoryContactEmail.DeleteRange(contact.Emails.ToArray());
            RepositoryContactPhone.DeleteRange(contact.Phones.ToArray()); 
            RepositoryContactRelated.DeleteRange(contact.RelatedContacts.ToArray()); 
            RepositoryContactAddress.DeleteRange(contact.Addresses.ToArray()); 
            RepositoryContactDate.DeleteRange(contact.Dates.ToArray()); 
            RepositoryContactWebsite.DeleteRange(contact.WebSites.ToArray()); 
            RepositoryContactIM.DeleteRange(contact.IMs.ToArray()); 
            RepositoryContactInternetCall.DeleteRange(contact.InternetCallIds.ToArray());

        }

        private void InsertContactDependants(Contact contact)
        {

            if(contact.Emails.Count>0)
                RepositoryContactEmail.SetSortOrder(contact.Emails.ToArray());

            if(contact.Phones.Count > 0)
                RepositoryContactPhone.SetSortOrder(contact.Phones.ToArray());

            if(contact.RelatedContacts.Count > 0)
                RepositoryContactRelated.SetSortOrder(contact.RelatedContacts.ToArray());

            if(contact.Addresses.Count > 0)
                RepositoryContactAddress.SetSortOrder(contact.Addresses.ToArray()); 

            if(contact.Dates.Count > 0)
                RepositoryContactDate.SetSortOrder(contact.Dates.ToArray());

            if(contact.WebSites.Count > 0)
                RepositoryContactWebsite.SetSortOrder(contact.WebSites.ToArray()); 

            if(contact.IMs.Count > 0)
                RepositoryContactIM.SetSortOrder(contact.IMs.ToArray()); 

            if(contact.InternetCallIds.Count > 0)
                RepositoryContactInternetCall.SetSortOrder(contact.InternetCallIds.ToArray());

        }

        private void FormatContactName(Contact contact)
        {
            contact.ContactName = string.Format("{0} {1} {2} {3}",
                contact.FirstName.Trim(),
                contact.LastName.Trim(),
                contact.NickName.Trim(),
                contact.ContactIdentification.BornInCountry.Trim()).Trim().Replace("  ", " ");
        } 

        public void UpdateContact(Contact contact)
        {
            InsertContactDependants(contact);

            FormatContactName(contact);

            _repoContact.Update(contact);
        }
        
        public void InsertContact(Contact contact)
        {
            InsertContactDependants(contact);

            FormatContactName(contact);

            RepositoryContact.Insert(contact);
        }

        public void DeleteContact(Contact Contact)
        {
            try
            {
                if (Contact != null)
                {
                    //  Cascade delete still not available in EF7-RC1!!! TODO: Change this as soon as cascade delete is available
                    foreach (var item in Contact.Phones)            RepositoryContactPhone.Delete(item);
                    foreach (var item in Contact.Emails)            RepositoryContactEmail.Delete(item);
                    foreach (var item in Contact.WebSites)          RepositoryContactWebsite.Delete(item);
                    foreach (var item in Contact.Addresses )        RepositoryContactAddress.Delete(item);
                    foreach (var item in Contact.Dates)             RepositoryContactDate.Delete(item);
                    foreach (var item in Contact.RelatedContacts)   RepositoryContactRelated.Delete(item);
                    foreach (var item in Contact.IMs)               RepositoryContactIM.Delete(item);
                    foreach (var item in Contact.InternetCallIds)   RepositoryContactInternetCall.Delete(item);

                    RepositoryContact.Delete(Contact);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                throw ex;
            }
        }

        public GenericRepository<Contact> RepositoryContact
        {
            get
            {
                if (this._repoContact == null)
                {
                    try
                    {
                        this._repoContact = new GenericRepository<Contact>(_context, _logger);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                    }
                }
                return this._repoContact;
            }
        }

        public GenericRepository<ContactEmail> RepositoryContactEmail
        {
            get
            {
                if (this._repoContactEmail == null)
                {
                    try
                    {
                        this._repoContactEmail = new GenericRepository<ContactEmail>(_context, _logger);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                    }
                }
                return this._repoContactEmail;
            }
        }

        public GenericRepository<ContactWebsite> RepositoryContactWebsite
        {
            get
            {
                if (this._repoContactWebsite == null)
                {
                    try
                    {
                        this._repoContactWebsite = new GenericRepository<ContactWebsite>(_context, _logger);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                    }
                }
                return this._repoContactWebsite;
            }
        }

        public GenericRepository<ContactPhone> RepositoryContactPhone
        {
            get
            {
                if (this._repoContactPhone == null)
                {
                    try
                    {
                        this._repoContactPhone = new GenericRepository<ContactPhone>(_context, _logger);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                    }
                }
                return this._repoContactPhone;
            }
        }

        public GenericRepository<ContactAddress> RepositoryContactAddress
        {
            get
            {
                if (this._repoContactAddress == null)
                {
                    try
                    {
                        this._repoContactAddress = new GenericRepository<ContactAddress>(_context, _logger);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                    }
                }
                return this._repoContactAddress;
            }
        }

        public GenericRepository<ContactDate> RepositoryContactDate
        {
            get
            {
                if (this._repoContactDate == null)
                {
                    try
                    {
                        this._repoContactDate = new GenericRepository<ContactDate>(_context, _logger);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                    }
                }
                return this._repoContactDate;
            }
        }

        public GenericRepository<ContactRelated> RepositoryContactRelated
        {
            get
            {
                if (this._repoContactRelated == null)
                {
                    try
                    {
                        this._repoContactRelated = new GenericRepository<ContactRelated>(_context, _logger);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                    }
                }
                return this._repoContactRelated;
            }
        }

        public GenericRepository<ContactInstantMessaging> RepositoryContactIM
        {
            get
            {
                if (this._repoContactIM == null)
                {
                    try
                    {
                        this._repoContactIM = new GenericRepository<ContactInstantMessaging>(_context, _logger);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                    }
                }
                return this._repoContactIM;
            }
        }

        public GenericRepository<ContactInternetCall> RepositoryContactInternetCall
        {
            get
            {
                if (this._repoContactInternetCall == null)
                {
                    try
                    {
                        this._repoContactInternetCall = new GenericRepository<ContactInternetCall>(_context, _logger);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                    }
                }
                return this._repoContactInternetCall;
            }
        }

        public GenericRepository<ContactIdentification> RepositoryContactIdentification
        {
            get
            {
                if (this._repoContactIdentification == null)
                {
                    try
                    {
                        this._repoContactIdentification = new GenericRepository<ContactIdentification>(_context, _logger);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                    }
                }
                return this._repoContactIdentification;
            }
        }

        public GenericRepository<ContactDharmaExperience> RepositoryContactDharmaExperience
        {
            get
            {
                if (this._repoContactDharmaExperience == null)
                {
                    try
                    {
                        this._repoContactDharmaExperience = new GenericRepository<ContactDharmaExperience>(_context, _logger);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                    }
                }
                return this._repoContactDharmaExperience;
            }
        }

        public GenericRepository<ContactEducation> RepositoryContactEducation
        {
            get
            {
                if (this._repoContactEducation == null)
                {
                    try
                    {
                        this._repoContactEducation = new GenericRepository<ContactEducation>(_context, _logger);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                    }
                }
                return this._repoContactEducation;
            }
        }

        public GenericRepository<ContactWorkPreference> RepositoryContactWorkPreference
        {
            get
            {
                if (this._repoContactWorkPreference == null)
                {
                    try
                    {
                        this._repoContactWorkPreference = new GenericRepository<ContactWorkPreference>(_context, _logger);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                    }
                }
                return this._repoContactWorkPreference;
            }
        }

        public GenericRepository<ContactVolunteeringExperience> RepositoryContactVolunteeringExperience
        {
            get
            {
                if (this._repoContactVolunteeringExperience == null)
                {
                    try
                    {
                        this._repoContactVolunteeringExperience = new GenericRepository<ContactVolunteeringExperience>(_context, _logger);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                    }
                }
                return this._repoContactVolunteeringExperience;
            }
        }

        public GenericRepository<ContactDonorInfo> RepositoryContactDonorInfo
        {
            get
            {
                if (this._repoContactDonorInfo == null)
                {
                    try
                    {
                        this._repoContactDonorInfo = new GenericRepository<ContactDonorInfo>(_context, _logger);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                    }
                }
                return this._repoContactDonorInfo;
            }
        }

        public GenericRepository<ContactHealthInfo> RepositoryContactHealthInfo
        {
            get
            {
                if (this._repoContactHealthInfo == null)
                {
                    try
                    {
                        this._repoContactHealthInfo = new GenericRepository<ContactHealthInfo>(_context, _logger);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                    }
                }
                return this._repoContactHealthInfo;
            }
        }

        public bool AreValidParams(string[] valuesArray, string columns, string tableKeys, string operators, string tables)
        {
            return 
            (
                PGUtil.SanitizeParamPostgres(valuesArray)   && 
                PGUtil.SanitizeParamPostgres(columns)       && 
                PGUtil.SanitizeParamPostgres(tableKeys)     && 
                PGUtil.SanitizeParamPostgres(operators)     &&
                PGUtil.SanitizeParamPostgres(tables)
            );
        }

        public string BuildQuery(string[] valuesArray, string columns, string tableKeys, string operators, string tables, int top = 15, bool count = false, int skip = 0)
        {

            string[] columnsArray = columns.Replace("'","").Split(',');
            string[] tablesKeysArray = (tableKeys == null )? new string[]{""}: tableKeys.Replace("'", "").Split(',');
            string[] operatorsArray = operators.Replace("\"", "").Replace("\\","").Split(',');

            int index = 0;

            StringBuilder query = new StringBuilder();

            if(count)
            {
                query.AppendFormat("SELECT COUNT(*) FROM \"Contact\"{0}", ((tables == null) ? string.Empty : string.Format(",{0}", tables.Substring(0, tables.Length - 1))));
            }
            else
            {
                query.Append("SELECT \"Contact\".\"Id\", \"Contact\".\"ContactName\",\"Contact\".\"Id\" details");
                foreach (string column in columnsArray)
                {
                    query.AppendFormat(",{0}", column);
                }
                query.Append(" FROM \"Contact\"");
                if(tables != null)
                    query.AppendFormat(",{0}",tables.Substring(0, tables.Length - 1));
            }

            query.Append(" WHERE ");

            if (tableKeys != null)
            {
                for (index = 0; index < tablesKeysArray.Length; index++)
                {
                    query.AppendFormat("\"Contact\".\"Id\" = {0} and ", tablesKeysArray[index]);
                }
            }
            if (valuesArray.Length > 0)
            {
                for (index = 0; index < valuesArray.Length; index++)
                {
                    var operatorX = operatorsArray[index];
                    if (operatorsArray[index].Substring(0, 1) == "#")
                    {
                        var regularExpressionStr = "#.+#";
                        var regExp = new  Regex(regularExpressionStr, RegexOptions.Multiline | RegexOptions.IgnoreCase );
                        operatorX = regExp.Replace( operatorsArray[index], "");

                        if(operatorX.Contains("LIKE"))
                        {
                            var fieldAndOperator = String.Format("lower({0}) {1}{2}", columnsArray[index], operatorX, ((index + 1) < valuesArray.Length) ? " and " : string.Empty);
                            query.AppendFormat(fieldAndOperator, (valuesArray[index] ?? string.Empty).ToLower());
                        }
                        else
                        {
                            query.AppendFormat("{0} {1}{2}{3}", columnsArray[index], operatorX, valuesArray[index].ToLower(), ((index + 1) < valuesArray.Length) ? " and " : string.Empty);
                        }
                    }
                }
            }
            if(!count)
            {
                query.AppendFormat(" ORDER BY \"Contact\".\"ContactName\"");
                if (top > 0)
                {
                    query.AppendFormat(" LIMIT {0}", top);
                }
                if (skip > 0)
                {
                    query.AppendFormat(" OFFSET {0}", skip);
                }
            }
            return query.ToString();
        }

        public IEnumerable<Dictionary<string, object>> RunQuery(string query)
        {
            return PGUtil.QueryToEnumerable(query);
        }

        public int RunCountQuery(string query)
        {
            return PGUtil.RunCountQuery(query);
        }

        public async Task SaveAsync()
        {
            try
            { 
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger .LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                throw ex;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //_context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
