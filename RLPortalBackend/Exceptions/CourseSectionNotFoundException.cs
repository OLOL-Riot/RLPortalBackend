namespace RLPortalBackend.Exceptions
{
    public class CourseSectionNotFoundException : NotFoundException
    {
        public CourseSectionNotFoundException(string message) : base(message)
        {
            Code = 404;
        }
    }
}
