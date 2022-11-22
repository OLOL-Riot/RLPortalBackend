namespace RLPortalBackend.Exceptions
{
    public class TestNotFoundException : NotFoundException
    {
        public TestNotFoundException(string message) : base(message)
        {
            Code = 400;
        }
    }
}
