using RLPortalBackend.Models.Exercise;

namespace RLPortalBackend.Models.Test
{
    /// <summary>
    /// NoRightAnswersTest
    /// </summary>
    public class NoRightAnswersTest
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Exercises <see cref="NoRightAnswerExercise"/>
        /// </summary>
        public ICollection<NoRightAnswerExercise> Exercises { get; set; }
    }
}
