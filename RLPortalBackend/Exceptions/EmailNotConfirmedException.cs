namespace RLPortalBackend.Exceptions
{
    public class EmailNotConfirmedException : HttpException
    {
        public EmailNotConfirmedException(string message) : base(message)
        {
            Code = 400;
        }
    }
}
