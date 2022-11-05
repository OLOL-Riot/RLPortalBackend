namespace RLPortalBackend.Exceptions
{
    public class UserNameAlredyExistsException : DataAlreadyExistsException
    {
        public UserNameAlredyExistsException(string message) : base(message)
        {
            Code = 409;
        }
    }
}
