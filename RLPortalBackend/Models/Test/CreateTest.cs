﻿using RLPortalBackend.Models.Exercise;

namespace RLPortalBackend.Models.Test
{
    public class CreateTest
    {
        public string Name { get; set; }

        public ICollection<NewExercise> Exercises { get; set; }
    }
}
