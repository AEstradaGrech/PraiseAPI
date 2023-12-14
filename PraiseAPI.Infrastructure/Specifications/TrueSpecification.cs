using PraiseAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Infrastructure.Specifications
{
    public class TrueSpecification<T> : Specification<T> where T : Entity
    {
        public TrueSpecification() : base(x => true) { }
    }
}
