namespace RLPortalBackend.Exceptions
{
    public class InvalidPhoneNumberException : InvalidDataException
    {
        public InvalidPhoneNumberException(string message) : base(message)
        {
            Code = 400;
        }
    }
}
