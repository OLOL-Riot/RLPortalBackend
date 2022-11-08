namespace RLPortalBackend.Exceptions
{
    public class DataAlreadyExistsException : HttpException
    {
        public DataAlreadyExistsException(string message) : base(message)
        {
            Code = 409;
        }
    }
}
