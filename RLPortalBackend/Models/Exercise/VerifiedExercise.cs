namespace RLPortalBackend.Models.Exercise
{
    /// <summary>
    /// VerifiedExercise
    /// </summary>
    public class VerifiedExercise
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Right answer
        /// </summary>
        public string RightAnswer { get; set; }

        /// <summary>
        /// IsRight
        /// </summary>
        public bool IsRight { get; set; }
    }
}