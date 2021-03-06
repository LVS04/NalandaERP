﻿using DNXTest.Models;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Reflection;

namespace DNXTest.Dal
{
    public class GenericRepository<TEntity> where TEntity : class
    {

        internal    ApplicationDbContext    _context;
        internal    DbSet<TEntity>          _dbSet;
        private     readonly ILogger        _logger;


        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            try
            {
                this._context   = context;
                this._dbSet     = context.Set<TEntity>();
                this._logger    = logger;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
            }

        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null/*,
            string includeProperties = ""*/)
        {
            try
            {

                IQueryable<TEntity> query = _dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                /*
                    foreach (string includeProperty in includeProperties.Split
                                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                query = query.Include  Include(includeProperty);
                            }
                */
                if (orderBy != null)
                {
                    return await orderBy(query).ToListAsync();
                }
                else
                {
                    return await query.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
            }
            return null;
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null/*,
            string includeProperties = ""*/)
        {
            try
            {
                IQueryable<TEntity> query = _dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                
                /*                foreach (string includeProperty in includeProperties.Split
                                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                query = query.Include  Include(includeProperty);
                            }
                            */
                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }
                else
                {
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                return null;
            }
        }

        //public virtual async Task<TEntity> GetByID(object id)
        //{
        //    try
        //    {
        //        return await _dbSet.FindAsync(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
        //        return null;
        //    }
        //}

        public virtual async Task<TEntity> GetByIDAsync(object id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
                return null;
            }
        }

        /// <summary>
        /// Using reflection to allow ordered Contact dependant collections
        /// </summary>
        /// <param name="entities"></param>
        public virtual void SetSortOrder(TEntity[] entities)
        {
            try
            {
                object typeProbe = entities[0];
                if (typeProbe.GetType().GetProperty("SortOrder") != null)
                {
                    int orderId = 0;
                    foreach (object e in entities)
                    {
                        PropertyInfo sortOrder = e.GetType().GetProperty("SortOrder");
                        sortOrder.SetValue(e, ++orderId);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
            }
        }

        public virtual void Insert(TEntity entity)
        {
            try
            {
                _dbSet.Add( entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
            }
        }

        public virtual void DeleteRange(TEntity[] entities)
        {
            try
            {
                foreach (var e in entities)
                {
                    if (_context.Entry(e).State == EntityState.Detached)
                    {
                        _dbSet.Attach(e);
                    }
                }
                _dbSet.RemoveRange(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
            }

        }

        public virtual async Task Delete(object id)
        {
            try
            {
                TEntity entityToDelete = await _dbSet.FindAsync(id);
                Delete(entityToDelete);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
            }
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            try
            {
                if (_context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    _dbSet.Attach(entityToDelete);
                }
                _dbSet.Remove(entityToDelete);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
            }
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            try
            {
                _dbSet.Attach(entityToUpdate);
                _context.Entry(entityToUpdate).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception caught on [{0}] - {1}", "System.Reflection.MethodBase.GetCurrentMethod().Name", ex.Message), ex);
            }
        }
    }
}
