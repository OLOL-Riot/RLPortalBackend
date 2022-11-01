namespace RLPortalBackend.Models.Exercise
{
    /// <summary>
    /// NewExercise
    /// </summary>
    public class NewExercise
    {
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Serial number
        /// </summary>
        public int SerialNumber { get; set; }

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
