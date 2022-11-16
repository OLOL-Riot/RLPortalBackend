namespace RLPortalBackend.Exceptions
{
    public class ExerciseNotFoundException : NotFoundException
    {
        public ExerciseNotFoundException(string message) : base(message)
        {
            Code = 400;
        }
    }
}
