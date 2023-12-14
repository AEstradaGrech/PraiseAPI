using PraiseAPI.Domain.DTOs.ResponseModels;

namespace PraiseAPI.Infrastructure.Utilities.ResponseModels
{
    public class CollectionResponse<T> : BaseResponse where T : class
    {

        public CollectionResponse(List<T> data, int? page = null, int? totalElements = null) : base()
        {
            Data = data;
            Page = page;
            TotalElements = totalElements;
        }

        public CollectionResponse(int errorCode, string msg) : base(errorCode, msg) { }
       
        public bool HasPagination() => Page != null && TotalElements != null;

        public int? Page { get; set; }
        public int? TotalElements { get; set; }
        public List<T> Data { get; set; }
    }
}
