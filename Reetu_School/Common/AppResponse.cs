using Microsoft.AspNetCore.Http;

namespace Reetu_School.Common
{
    public class AppResponse<T>
    {
        public StatusCode StatusCode { get; set; } = StatusCode.Error;
        public string Message { get; set; } = "Something went wrong....";
        public T Result { get; set; }
    }
    public class AppResponse
    {
        public StatusCode StatusCode { get; set; } = StatusCode.Error;
        public string Message { get; set; } = "Something went wrong....";
    }
}
