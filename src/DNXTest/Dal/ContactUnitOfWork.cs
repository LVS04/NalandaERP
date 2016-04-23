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
        private ApplicationDbContext                    _context;
        private GenericRepository<Contact>              _repoContact;
        private readonly ILogger                        _logger;

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
