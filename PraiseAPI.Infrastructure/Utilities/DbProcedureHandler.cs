using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Newtonsoft.Json;
using PraiseAPI.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Infrastructure.Utilities
{
    /*
     var pInfo = [EmployeeInstance].GetType().GetProperties().FirstOrDefault(p => p.GetCustomAttributes<JsonPropertyAttribute>().Any(at => at.PropertyName.Equals("emp_lname")))
     */
    public class DbProcedureHandler : IDbParamsHandler
    {
        public DbProcedureHandler(string procName) { ProcName = procName; ProcParams = new Dictionary<string, KeyValuePair<DbType, object>>(); }

        public Dictionary<string, KeyValuePair<DbType, object>> ProcParams { get; set; }

        public string ProcName { get; set; }

        public bool IsValid()
            => !string.IsNullOrEmpty(ProcName);

        public void SetParams(object request)
        {
            request.GetType().GetProperties().ToList().ForEach(p => {
                
                DbType? type = GetDbType(p);

                if (p.GetValue(request, null) != null)
                {
                    object value = (object)p.GetValue(request, null);

                    if (type.HasValue)
                    {
                        var kvp = new KeyValuePair<DbType, object>(type.Value, value);
                        
                        ProcParams.Add(p.Name, kvp);
                    }
                       
                }
                
            });
        }

        private DbType? GetDbType(PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(string)) return DbType.String;

            if(prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?)) return DbType.Int32;

            if(prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?)) return DbType.DateTime;

            if (prop.PropertyType == typeof(float) || prop.PropertyType == typeof(float?)) return DbType.Double;

            if(prop.PropertyType == typeof(decimal) || prop.PropertyType == typeof(decimal?)) return DbType.Decimal;

            return null;
        }
    }
}
