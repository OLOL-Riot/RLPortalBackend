namespace RLPortalBackend.Models.CourseSection
{
    public class CourseSectionDto
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
        /// ShortDescription
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// SerialNumber
        /// </summary>
        public int SerialNumber { get; set; }

        /// <summary>
        /// TheoryEntityId
        /// </summary>
        public Guid TheoryId { get; set; }

        /// <summary>
        /// TestEntityId
        /// </summary>
        public Guid TestId { get; set; }
    }
}
