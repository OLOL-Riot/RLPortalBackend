namespace RLPortalBackend.Models.CourseSection
{
    public class CreateCourseSectionDto
    {
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
        /// Course id
        /// </summary>
        public Guid? CourseId { get; set; }
    }
}
