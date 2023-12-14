using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Localization;
using PraiseAPI.Domain.Entities;
using PraiseAPI.Domain.Repositories;
using PraiseAPI.Infrastructure.Context;
using PraiseAPI.Infrastructure.Resources;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly IUnitOfWork _UoW;
        protected readonly IStringLocalizer<DbError> _errorLoc;
        
        public DbSet<T> DbSet => _dbSet;

        public BaseRepository(PraiseDbContext context, IStringLocalizer<DbError> errorLoc)
        {
            _dbSet = context.Set<T>() ?? throw new ArgumentNullException(nameof(context));
            _UoW = context;
            _errorLoc = errorLoc;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable<T>();
        }

        public T GetById(int id)
        {
            if (_dbSet.Any(x => x.Id == id))
                return _dbSet.SingleOrDefault(x => x.Id == id);

            return null;
        }

        public T Post(T entity)
        {
            var newEntry = _dbSet.Add(entity);

            return _UoW.SaveEntities() ? newEntry.Entity : null;
        }

        public T Update(T entity)
        {
            var updatedEntry = _dbSet.Update(entity);

            return _UoW.SaveEntities() ? updatedEntry.Entity : null;
        }


        public T DeleteById(int id)
        {
            if (_dbSet.Any(x => x.Id == id))
            {
                var entity = _dbSet.SingleOrDefault(x => x.Id == id);

                _dbSet.Remove(entity);

                return _UoW.SaveEntities() ? entity : null;
            }

            return null;
        }

        public T Delete(T entity)
        {
            var deletedEntry = _dbSet.Remove(entity);

            return _UoW.SaveEntities() ? deletedEntry.Entity : null;
        }

        public virtual bool CanAdd(T entity, out ApiError outError)
        {
            outError = new ApiError();

            return true;
        }
    }
}
