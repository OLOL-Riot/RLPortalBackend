namespace RLPortalBackend.Exceptions
{
    public class InvalidDataException : HttpException
    {
        public InvalidDataException(string message) : base(message)
        {
            Code = 400;
        }
    }
}
