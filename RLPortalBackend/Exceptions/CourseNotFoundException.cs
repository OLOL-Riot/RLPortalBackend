namespace RLPortalBackend.Exceptions
{
    public class CourseNotFoundException : NotFoundException
    {
        public CourseNotFoundException(string message) : base(message)
        {
            Code = 400;
        }
    }
}
