using RLPortalBackend.Models.Theory;

namespace RLPortalBackend.Models.CourseSection
{
    /// <summary>
    /// CourseSectionDto
    /// </summary>
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
        /// TheoryDto
        /// </summary>
        public TheoryDto TheoryDto { get; set; }

        /// <summary>
        /// TestEntityId
        /// </summary>
        public Guid TestEntityId { get; set; }
    }
}
