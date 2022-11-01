namespace RLPortalBackend.Models.Exercise
{
    /// <summary>
    /// NoRightAnswerExercise
    /// </summary>
    public class NoRightAnswerExercise
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

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
    }
}
