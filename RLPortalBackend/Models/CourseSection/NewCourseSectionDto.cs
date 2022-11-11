using RLPortalBackend.Models.Test;
using RLPortalBackend.Models.Theory;

namespace RLPortalBackend.Models.CourseSection
{
    /// <summary>
    /// NewCourseSectionDto
    /// </summary>
    public class NewCourseSectionDto
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
    }
}
