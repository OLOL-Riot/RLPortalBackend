﻿using RLPortalBackend.Models.Exercise;

namespace RLPortalBackend.Models.Test
{
    public class Test
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Exercise.Exercise> Exercises { get; set; }
    }
}