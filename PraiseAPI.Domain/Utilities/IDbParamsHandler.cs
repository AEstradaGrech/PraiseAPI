using System.Data;


namespace PraiseAPI.Domain.Utilities
{
    public interface IDbParamsHandler
    {
        string ProcName { get; set; }

        Dictionary<string, KeyValuePair<DbType, object>> ProcParams { get; set; }

        void SetParams(object request);

        bool IsValid();
    }
}
