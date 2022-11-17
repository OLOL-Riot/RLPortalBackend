namespace RLPortalBackend.Exceptions
{
    public class InvalidRoleException: HttpException
    {
        public InvalidRoleException(string message) : base(message)
        {
            Code = 400;
        }
    }
}
