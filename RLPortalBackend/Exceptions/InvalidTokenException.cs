namespace RLPortalBackend.Exceptions
{
    public class InvalidTokenException : HttpException
    {
        public InvalidTokenException(string message) : base( message)
        {
            Code = 404;
        }
    }
}
