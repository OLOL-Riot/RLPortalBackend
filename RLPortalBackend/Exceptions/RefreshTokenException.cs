namespace RLPortalBackend.Exceptions
{
    public class RefreshTokenException : HttpException
    {
        public RefreshTokenException(string message) : base(message)
        {
            Code = 403;
        }
    }
}
