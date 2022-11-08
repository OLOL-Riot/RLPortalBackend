namespace RLPortalBackend.Exceptions
{
    public class DataMatchException : HttpException
    {
        public DataMatchException(string message) : base(message)
        {
            Code = 409;
        }
    }
}
