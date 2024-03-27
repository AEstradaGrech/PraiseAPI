using Microsoft.EntityFrameworkCore;
using PraiseAPI.Domain.Entities;
using PraiseAPI.Domain.Specifications;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;

namespace PraiseAPI.Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(int id);
        IQueryable<T> Query(ISpecification<T> specification);
        IEnumerable<T> GetAll();
        T Update(T entity);
        T Add(T entity);
        T Delete(T entity);
        T DeleteById(int id);
        DbSet<T> DbSet { get; }
        bool CanAdd(T entity, out ApiError outError);
    }
}
