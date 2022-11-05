namespace RLPortalBackend.Exceptions
{
    public class PasswordMatchException : DataMatchException
    {
        public PasswordMatchException(string message) : base(message)
        {
            Code = 409;
        }
    }
}
