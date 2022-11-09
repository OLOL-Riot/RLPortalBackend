using RLPortalBackend.Models.CourseSection;

namespace RLPortalBackend.Models.Course
{
    public class CourseDto
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
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ShortDescription
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// PreviewCourseSections
        /// </summary>
        public ICollection<PreviewCourseSectionDto> PreviewCourseSections { get; set; }
    }
}
