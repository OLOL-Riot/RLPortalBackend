using RLPortalBackend.Entities;

namespace RLPortalBackend.Models.VerifiedTest
{
    public class VerifiedTestDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid TestId { get; set; }

        public int Points { get; set; }

        public int MaxPoints { get; set; }

        public ICollection<UserAnswerDto> UserAnswers { get; set; }
    }
}
