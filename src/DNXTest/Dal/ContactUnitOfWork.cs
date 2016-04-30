using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNXTest.Models;
using Microsoft.Extensions.Logging;


namespace DNXTest.Dal
{
    public class ContactUnitOfWork : IDisposable
    {
        private ApplicationDbContext _context;
        private readonly ILogger _logger;

        private GenericRepository<Contact> _repoContact;
        private GenericRepository<ContactEmail> _repoContactEmail;
        private GenericRepository<ContactPhone> _repoContactPhone;
        private GenericRepository<ContactRelated> _repoContactRelated;
        private GenericRepository<ContactAddress> _repoContactAddress;
        private GenericRepository<ContactDate> _repoContactDate;
        private GenericRepository<ContactWebsite> _repoContactWebsite;
        private GenericRepository<ContactInstantMessaging> _repoContactIM;
        private GenericRepository<ContactInternetCall> _repoContactInternetCall;

        private GenericRepository<ContactIdentification> _repoContactIdentification;
        private GenericRepository<ContactDharmaExperience> _repoContactDharmaExperience;
        private GenericRepository<ContactEducation> _repoContactEducation;
        private GenericRepository<ContactWorkPreference> _repoContactWorkPreference;
        private GenericRepository<ContactVolunteeringExperience> _repoContactVolunteeringExperience;
        private GenericRepository<ContactDonorInfo> _repoContactDonorInfo;
        private GenericRepository<ContactHealthInfo> _repoContactHealthInfo;


        public ContactUnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("LoggerUnitOfWork");
        }

        public Contact GetContactById(Guid id)
        {
            try
            {

                Contact _contact;

                _contact = RepositoryContact.GetByID(id);
                if (_contact != null)
                {
                    _contact.Addresses = (ICollection<ContactAddress>)RepositoryContactAddress.Get(a => a.Contact.Id == id).OrderByDescending(o => o.Id).ToList();
                    _contact.Dates = (ICollection<ContactDate>)RepositoryContactDate.Get(a => a.Contact.Id == id).OrderByDescending(o => o.Id).ToList();
                    _contact.Phones = (ICollection<ContactPhone>)RepositoryContactPhone.Get(a => a.Contact.Id == id).OrderBy(o => o.Id).ToList();
                    _contact.RelatedContacts = (ICollection<ContactRelated>)RepositoryContactRelated.Get(a => a.Contact.Id == id).OrderByDescending(o => o.Id).ToList();
                    _contact.Emails = (ICollection<ContactEmail>)RepositoryContactEmail.Get(a => a.Contact.Id == id).OrderByDescending(o => o.Id).ToList();
                    _contact.WebSites = (ICollection<ContactWebsite>)RepositoryContactWebsite.Get(a => a.Contact.Id == id).OrderByDescending(o => o.Id).ToList();
                    _contact.IMs = (ICollection<ContactInstantMessaging>)RepositoryContactIM.Get(a => a.Contact.Id == id).OrderByDescending(o => o.Id).ToList();
                    _contact.InternetCallIds = (ICollection<ContactInternetCall>)RepositoryContactInternetCall.Get(a => a.Contact.Id == id).OrderByDescending(o => o.Id).ToList();

                    _contact.ContactIdentification = (ContactIdentification)RepositoryContactIdentification.Get(a => a.Contact.Id == id).FirstOrDefault();
                    _contact.ContactDharmaExperience = (ContactDharmaExperience)RepositoryContactDharmaExperience.Get(a => a.Contact.Id == id).FirstOrDefault();
                    _contact.ContactEducation = (ContactEducation)RepositoryContactEducation.Get(a => a.Contact.Id == id).FirstOrDefault();
                    _contact.ContactWorkPreference = (ContactWorkPreference)RepositoryContactWorkPreference.Get(a => a.Contact.Id == id).FirstOrDefault();
                    _contact.ContactVolunteeringExperience = (ContactVolunteeringExperience)RepositoryContactVolunteeringExperience.Get(a => a.Contact.Id == id).FirstOrDefault();
                    _contact.ContactDonorInfo = (ContactDonorInfo)RepositoryContactDonorInfo.Get(a => a.Contact.Id == id).FirstOrDefault();
                    _contact.ContactHealthInfo = (ContactHealthInfo)RepositoryContactHealthInfo.Get(a => a.Contact.Id == id).FirstOrDefault();
                }

                return _contact;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                throw ex;

            }
        }

        public void DeleteContactById(Guid Id)
        {
            try
            {
                //  Cascade delete still not available in EF7!!! TODO: Change this as soon as cascade delete is available
                try
                {
                    var phones = RepositoryContactPhone.Get().Where(x => x.Contact.Id == Id).ToList();
                    foreach (var phone in phones) RepositoryContactPhone.Delete(phone);
                }
                catch { }
                try
                {
                    var emails = RepositoryContactEmail.Get().Where(x => x.Contact.Id == Id).ToList();
                    foreach (var email in emails) RepositoryContactEmail.Delete(email);
                }
                catch { }
                try
                {
                    var websites = RepositoryContactWebsite.Get().Where(x => x.Contact.Id == Id).ToList();
                    foreach (var website in websites) RepositoryContactEmail.Delete(website);
                }
                catch { }
                try
                {
                    var addresses = RepositoryContactAddress.Get().Where(x => x.Contact.Id == Id).ToList();
                    foreach (var address in addresses) RepositoryContactEmail.Delete(address);
                }
                catch { }
                try
                {
                    var dates = RepositoryContactDate.Get().Where(x => x.Contact.Id == Id).ToList();
                    foreach (var date in dates) RepositoryContactEmail.Delete(date);
                }
                catch { }
                try
                {
                    var relateds = RepositoryContactRelated.Get().Where(x => x.Contact.Id == Id).ToList();
                    foreach (var related in relateds) RepositoryContactEmail.Delete(related);
                }
                catch { }
                try
                {
                    var ims = RepositoryContactIM.Get().Where(x => x.Contact.Id == Id).ToList();
                    foreach (var im in ims) RepositoryContactEmail.Delete(im);
                }
                catch { }
                try
                {
                    var intcalls = RepositoryContactInternetCall.Get().Where(x => x.Contact.Id == Id).ToList();
                    foreach (var intcall in intcalls) RepositoryContactEmail.Delete(intcall);
                }
                catch { }

                RepositoryContact.Delete(Id);

                this.Save();

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
                    catch(Exception ex)
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

        public void Save()
        {
            try
            { 
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                throw ex;
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
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
                    _context.Dispose();
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
