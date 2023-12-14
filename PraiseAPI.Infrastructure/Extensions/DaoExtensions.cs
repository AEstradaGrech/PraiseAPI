using Microsoft.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using PraiseAPI.Infrastructure.Utilities;
using System.Data;
using System.Data.Common;

namespace PraiseAPI.Infrastructure.Extensions
{
    public static class DaoExtensions
    {
        public static DbCommand SetupCommand(this DbCommand cmd, DbProcedureHandler handler, Database db)
        {
            foreach (string key in handler.ProcParams.Keys)
                db.AddInParameter(cmd, $"@{key}", handler.ProcParams[key].Key, handler.ProcParams[key].Value);
            
            return cmd;
        }

        public static DbCommand AddDataTableParam(this DbCommand cmd, List<int> values, string paramName = "@FLT_LIST")
        {
            if (values.Count <= 0) return cmd;

            paramName = paramName.Substring(1) == "@" ? paramName : $"@{paramName}";

            DataTable table = new DataTable(paramName);

            table.Columns.Add("VALS", typeof(int));

            values.ForEach(v => table.Rows.Add(v));

            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter(paramName, table);

            param.SqlDbType = SqlDbType.Structured;
            param.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(param);

            return cmd;
        }

    }
}
