namespace RLPortalBackend.Exceptions
{
    public class UserNameNotFoundException : NotFoundException
    {
        public UserNameNotFoundException(string message) : base(message)
        {
            Code = 400;
        }
    }
}
