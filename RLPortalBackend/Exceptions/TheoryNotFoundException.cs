namespace RLPortalBackend.Exceptions
{
    public class TheoryNotFoundException : NotFoundException
    {
        public TheoryNotFoundException(string message) : base(message)
        {
            Code = 404;
        }
    }
}
