namespace RLPortalBackend.Exceptions
{
    /// <summary>
    /// HttpException
    /// </summary>
    public class HttpException : Exception
    {
        /// <summary>
        /// Http status code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// HttpException constructor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public HttpException(int code, string message) : base(message)
        {
            Code = code;
        }

        public HttpException(string message) : base(message)
        {
        }


    }
}
