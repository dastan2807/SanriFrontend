using Microsoft.EntityFrameworkCore;
using SanriJP.API.Authentication;
using SanriJP.API.DataContext;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace SanriJP.API.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<(Response, TEntity)> AddAsync(TEntity entity);
        Task<Response> DeleteAsync(Expression<Func<TEntity, bool>> match);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> match);
        Task<(Response, TEntity)> UpdateAsync(TEntity entityToUpdate);
        Task<Response> UpdateWithoutNullAsync(TEntity entityToUpdate);
    }
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly AppDbContext _db;
        private readonly DbSet<TEntity> _dbSet;

        protected RepositoryBase(AppDbContext db)
            => (_db, _dbSet) = (db, db.Set<TEntity>());

        public virtual async Task<(Response, TEntity)> AddAsync(TEntity entity)
        {
            try
            {
                await _db.Set<TEntity>().AddAsync(entity);
                await _db.SaveChangesAsync();
                return (new Response { Status = ResponseStatus.Succes, Message = typeof(TEntity) + " created successfully!" }, entity);
            }
            catch (Exception ex)
            {
                return (new Response { Status = ResponseStatus.Error, Message = typeof(TEntity) + " creation failed! Please check " + typeof(TEntity) + " details and try again. " + ex }, entity);
            }
        }

        public async Task<Response> DeleteAsync(Expression<Func<TEntity, bool>> match)
        {
            var resultExists = await _db.Set<TEntity>().FirstOrDefaultAsync(match);
            if (resultExists == null)
                return new Response { Status = ResponseStatus.Error, Message = typeof(TEntity) + " doesn't exists!" };

            try
            {
                _db.Set<TEntity>().Remove(resultExists);
                _db.SaveChanges();
                return new Response { Status = ResponseStatus.Succes, Message = typeof(TEntity) + " deleted successfully!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = ResponseStatus.Error, Message = typeof(TEntity) + " creation failed! Please check " + typeof(TEntity) + " details and try again. " + ex };
            }
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        => await _db.Set<TEntity>().AsNoTracking().ToListAsync();

        public virtual async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> match)
        => await _db.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(match);

        public virtual async Task<(Response, TEntity)> UpdateAsync(TEntity entityToUpdate)
        {
            try
            {
                if (_db.Entry(entityToUpdate).State == EntityState.Detached)
                {
                    _dbSet.Attach(entityToUpdate);
                }

                _db.Entry(entityToUpdate).State = EntityState.Modified;
                _db.ChangeTracker.AutoDetectChangesEnabled = false;
                await _db.SaveChangesAsync();
                return (new Response { Status = ResponseStatus.Succes, Message = typeof(TEntity) + " updated successfully!" }, entityToUpdate);
            }
            catch (Exception ex)
            {
                return (new Response { Status = ResponseStatus.Error, Message = typeof(TEntity) + " update failed! Please check Auction details and try again. " + ex }, entityToUpdate);
            }
        }
        public virtual async Task<Response> UpdateWithoutNullAsync(TEntity entityToUpdate)
        {
            try
            {
                if (_db.Entry(entityToUpdate).State == EntityState.Detached)
                {
                    _dbSet.Attach(entityToUpdate);
                }

                _db.Entry(entityToUpdate).State = EntityState.Modified;

                Type type = typeof(TEntity);
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (property.GetValue(entityToUpdate, null) == null)
                    {
                        _db.Entry(entityToUpdate).Property(property.Name).IsModified = false;
                    }
                }
                _db.ChangeTracker.AutoDetectChangesEnabled = false;
                await _db.SaveChangesAsync();
                return new Response { Status = ResponseStatus.Succes, Message = typeof(TEntity) + " updated successfully!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = ResponseStatus.Error, Message = typeof(TEntity) + " update failed! Please check Auction details and try again. " + ex };
            }
        }
    }
}
