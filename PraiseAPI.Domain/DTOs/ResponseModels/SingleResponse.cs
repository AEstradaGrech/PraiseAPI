using PraiseAPI.Domain.DTOs.ResponseModels;

namespace PraiseAPI.Infrastructure.Utilities.ResponseModels
{
    public class SingleResponse<T> : BaseResponse where T : class
    {
        public SingleResponse(T data) : base()
        {
            Data = data;
        }

        public SingleResponse(int errorCode, string msg) : base(errorCode, msg) { }

        public T Data { get; set; }
    }
}
