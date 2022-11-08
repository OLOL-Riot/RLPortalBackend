using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Entities
{
    /// <summary>
    /// Theory section entity
    /// </summary>
    public class TheorySectionEntity
    {

        /// <summary>
        /// SerialNumber
        /// </summary>
        public int SerialNumber { get; set; }

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
