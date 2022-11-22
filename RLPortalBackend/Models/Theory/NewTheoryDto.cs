using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.Theory
{
    /// <summary>
    /// NoIdTheoryDto
    /// </summary>
    public class NewTheoryDto
    {
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// ShortDescription
        /// </summary>
        [Required]
        public string ShortDescription { get; set; }

        /// <summary>
        /// TheorySectionDtos
        /// </summary>
        [Required]
        public ICollection<TheorySectionDto> TheorySectionDtos { get; set; }
    }
}
