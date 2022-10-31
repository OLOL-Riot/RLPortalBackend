using System.Net;

namespace RLPortalBackend.Exeption
{
    public class HttpException : Exception
    {
        public HttpStatusCode Code { get; set; }

        public HttpException(HttpStatusCode code, string message) : base(message)
        {
            Code = code;
        }


    }
}
