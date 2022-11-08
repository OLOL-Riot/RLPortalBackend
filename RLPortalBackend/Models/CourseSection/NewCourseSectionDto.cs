﻿namespace RLPortalBackend.Models.CourseSection
{
    public class NewCourseSectionDto
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public ICollection<Guid> TheoryEntityId { get; set; }
        public ICollection<Guid> TestEntityId { get; set; }
    }
}