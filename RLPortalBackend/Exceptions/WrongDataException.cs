namespace RLPortalBackend.Exceptions
{
    public class WrongDataException : HttpException
    {
        public WrongDataException(string message) : base(message)
        {
            Code = 400;
        }
    }
}
