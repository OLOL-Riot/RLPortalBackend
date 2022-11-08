﻿using System.ComponentModel.DataAnnotations;

namespace RLPortalBackend.Models.Theory
{
    /// <summary>
    /// CreateTheoryDto
    /// </summary>
    public class CreateTheoryDto
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
        /// TheorySectionEntities
        /// </summary>
        [Required]
        public ICollection<CreateTheorySectionDto> CreateTheorySectionDtos { get; set; }
    }
}