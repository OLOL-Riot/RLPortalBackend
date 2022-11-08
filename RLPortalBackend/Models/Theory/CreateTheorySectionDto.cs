using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.Theory
{
    /// <summary>
    /// CreateTheorySectionDto
    /// </summary>
    public class CreateTheorySectionDto
    {
        /// <summary>
        /// Header
        /// </summary>
        [Required]
        public string Header { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        [Required]
        public string Content { get; set; }

    }
}
