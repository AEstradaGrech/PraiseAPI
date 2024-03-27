using PraiseAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.Specifications
{
    public interface ISpecification<T> where T : Entity
    {
        Expression<Func<T, bool>> Predicate { get; }
        Expression<Func<T, bool>> Criteria();
    }
}
