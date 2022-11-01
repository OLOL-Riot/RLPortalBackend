using System.Net;

namespace RLPortalBackend.Exeption
{
    /// <summary>
    /// HttpException
    /// </summary>
    public class HttpException : Exception
    {
        /// <summary>
        /// Http status code
        /// </summary>
        public HttpStatusCode Code { get; set; }

        /// <summary>
        /// HttpException constructor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public HttpException(HttpStatusCode code, string message) : base(message)
        {
            Code = code;
        }


    }
}
