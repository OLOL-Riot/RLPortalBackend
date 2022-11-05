namespace RLPortalBackend.Exceptions
{
    public class WrongPasswordException : WrongDataException
    {
        public WrongPasswordException(string message) : base(message)
        {
            Code = 400;
        }
    }
}
