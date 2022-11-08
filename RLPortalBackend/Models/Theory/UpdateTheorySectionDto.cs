using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.Theory
{
    /// <summary>
    /// UpdateTheorySectionDto
    /// </summary>
    public class UpdateTheorySectionDto
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
