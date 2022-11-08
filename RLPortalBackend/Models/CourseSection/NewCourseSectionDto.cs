using RLPortalBackend.Models.Test;
using RLPortalBackend.Models.Theory;

namespace RLPortalBackend.Models.CourseSection
{
    public class NewCourseSectionDto
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public int SerialNumber { get; set; }
        public ICollection<NoIdTheoryDto> TheoryDtos { get; set; }
        public ICollection<CreateTest> TestDtos { get; set; }
    }
}
