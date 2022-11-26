namespace RLPortalBackend.Exceptions
{
    public class MailNotConfirmed : HttpException
    {
        public MailNotConfirmed(string message) : base(message)
        {
            Code = 400;
        }
    }
}
