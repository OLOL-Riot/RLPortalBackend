using RLPortalBackend.Entities;

namespace RLPortalBackend.Models.VerifiedTest
{
    public class VerifiedTestDto
    {
        public Guid Id { get; set; }    

        public string Username { get; set; }

        public Guid TestId { get; set; }

        public int Points { get; set; }

        public int MaxPoints { get; set; }

        public ICollection<VerifiedExerciseDto> VerifiedAnswers { get; set; }
    }
}
