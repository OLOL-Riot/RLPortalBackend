namespace RLPortalBackend.Exceptions
{
    public class EmailAlredyExistsException : DataAlreadyExistsException
    {
        public EmailAlredyExistsException(string message) : base(message)
        {
            Code = 409;
        }
    }
}
