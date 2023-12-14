using PraiseAPI.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.Repositories.DAOs
{
    public interface IBaseDAO<T> where T : class, new()
    {
        List<T> GetCollectionByCmd<T>(DbCommand cmd) where T : class, new();
        List<T> ExecuteProcedure<T>(IDbParamsHandler paramsHandler) where T : class, new();
    }
}
