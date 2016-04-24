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
        private ApplicationDbContext                            _context;
        private GenericRepository<Contact>                      _repoContact;
        private GenericRepository<ContactEmail>                 _repoContactEmail;
        private GenericRepository<ContactPhone>                 _repoContactPhone;
        private GenericRepository<ContactAddress>               _repoContactAddress;
        private GenericRepository<ContactDate>                  _repoContactDate;
        private GenericRepository<ContactRelated>               _repoContactRelated;
        private GenericRepository<ContactWebsite>               _repoContactWebsite;
        private GenericRepository<ContactInstantMessaging>      _repoContactIM;
        private GenericRepository<ContactInternetCall>          _repoContactInternetCall;

        private readonly ILogger                                _logger;

        public ContactUnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("LoggerUnitOfWork");
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

        public void Save()
        {
            try
            { 
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
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
