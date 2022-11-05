namespace RLPortalBackend.Exceptions
{
    public class InvalidEmailException : InvalidDataException
    {
        public InvalidEmailException(string message) : base(message)
        {
            Code = 400;
        }
    }
}
