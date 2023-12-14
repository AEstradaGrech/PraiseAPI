using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using PraiseAPI.Domain.Repositories.DAOs;
using PraiseAPI.Domain.Services;
using PraiseAPI.Domain.Utilities;
using PraiseAPI.Infrastructure.Extensions;
using PraiseAPI.Infrastructure.Utilities;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;
using System.Data;
using System.Data.Common;
using System.Net;

namespace PraiseAPI.Infrastructure.Repositories.DAOs
{
    public class BaseDAO<T> : IBaseDAO<T> where T : class, new()
    {
        protected readonly Database _dB;
        protected readonly IApiLogService _logService;

        public BaseDAO(IConfiguration appConfig, IApiLogService apiLog) 
        {
            _dB = new Microsoft.Practices.
                    EnterpriseLibrary.Data.Sql.SqlDatabase(@"Data Source=localhost;User Id=sa;Password=1PraiseApi*Dev!;Database=PraiseDB;Integrated Security=false;Trusted_Connection=false;TrustServerCertificate=true");
            
            _logService = apiLog;
        }

        protected DataSet GetDataSet(DbCommand cmd)
        {
            return _dB.ExecuteDataSet(cmd);
        }

        public List<T> GetCollectionByCmd<T>(DbCommand cmd) where T : class, new()
        {
            var results = new List<T>();

            try
            {
                var set = GetDataSet(cmd);

                return IsValidDataSet(set) ? MapCollection<T>(set.Tables[0]) : results;
            }
            catch(Exception ex)
            {
                _logService.Log(new ApiError((int)HttpStatusCode.InternalServerError, ex.Message));
            }
            finally
            {
                cmd.Dispose();
            }

            return results;
        }

        public List<T> ExecuteProcedure<T>(IDbParamsHandler paramsHandler) where T : class, new()
        {
            List<T> results = new List<T>();

            if (!paramsHandler.IsValid()) return results;
            
            using DbCommand cmd = _dB.GetStoredProcCommand(paramsHandler.ProcName);

            try
            {
                cmd.SetupCommand((DbProcedureHandler)paramsHandler, _dB);

                var set = GetDataSet(cmd);

                return IsValidDataSet(set) ? MapCollection<T>(set.Tables[0]) : results;
            }
            catch (Exception ex)
            {
                _logService.Log(new ApiError((int)HttpStatusCode.InternalServerError, ex.Message));
            }
            finally
            {
                cmd.Dispose();
            }

            return results;
        }

        protected List<T> MapCollection<T>(DataTable table) where T : class, new()
        {
            List<T> results = new List<T>();

            foreach(DataRow row in table.Rows)
                results.Add((T)Activator.CreateInstance(typeof(T), row));
           
            return results;
        }

        protected bool IsValidDataSet(DataSet set)
            => set.Tables.Count > 0 && set.Tables[0].Rows.Count > 0;
    }
}
