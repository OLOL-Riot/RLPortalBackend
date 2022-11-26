namespace RLPortalBackend.Exceptions
{
    public class InvalidJwtException : HttpException
    {
        public InvalidJwtException(string message) : base(message)
        {
            Code = 400;
        }
    }
}
