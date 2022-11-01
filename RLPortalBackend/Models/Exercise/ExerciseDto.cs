namespace RLPortalBackend.Models.Exercise
{
    /// <summary>
    /// ExerciseDto
    /// </summary>
    public class ExerciseDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Serial number
        /// </summary>
        public int SerialNumber { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Answers
        /// </summary>
        public ICollection<string> Answers { get; set; }

        /// <summary>
        /// RightAnswer
        /// </summary>
        public string RightAnswer { get; set; }
    }
}
