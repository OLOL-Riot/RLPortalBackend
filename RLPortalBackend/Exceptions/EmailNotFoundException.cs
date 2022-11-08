namespace RLPortalBackend.Exceptions
{
    public class EmailNotFoundException : NotFoundException
    {
        public EmailNotFoundException(string message) : base(message)
        {
            Code = 400;
        }
    }
}
