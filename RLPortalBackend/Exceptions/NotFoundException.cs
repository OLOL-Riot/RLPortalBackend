namespace RLPortalBackend.Exceptions
{
    public class NotFoundException : HttpException
    {
        public NotFoundException(string message) : base(message)
        {
            Code = 404;
        }
    }
}
