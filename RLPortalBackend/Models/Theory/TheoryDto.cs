namespace RLPortalBackend.Models.Theory
{
    /// <summary>
    /// TheoryDto
    /// </summary>
    public class TheoryDto
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
        /// TheorySectionDtos
        /// </summary>
        public ICollection<TheorySectionDto> TheorySections { get; set; }
    }
}
