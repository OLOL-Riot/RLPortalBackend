namespace RLPortalBackend.Exceptions
{
    public class InvalidPasswordException : InvalidDataException
    {
        public InvalidPasswordException(string message) : base(message)
        {
            Code = 400;
        }
    }
}
