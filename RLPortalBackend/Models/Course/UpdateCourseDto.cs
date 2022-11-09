namespace RLPortalBackend.Models.Course
{
    public class UpdateCourseDto
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ShortDescription
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// CourseSectionIds
        /// </summary>
        public ICollection<Guid> CourseSectionIds { get; set; }
    }
}
