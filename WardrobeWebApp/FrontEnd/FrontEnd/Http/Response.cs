using System.Net;

namespace FrontEnd.Http
{
    public class Response<T>
    {
        public T? ResponseObject { get; set; }
        public bool HasError { get; set; }
        public string? ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
