namespace RLPortalBackend.Entities
{
    public class CourseSectionEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public ICollection<Guid> TheoryEntityId { get; set; }
        public ICollection<Guid> TestEntityId { get; set; }

    }
}
