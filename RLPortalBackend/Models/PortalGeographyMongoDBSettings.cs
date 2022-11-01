namespace RLPortalBackend.Models
{
    /// <summary>
    /// MongoDB settings
    /// </summary>
    public class PortalGeographyMongoDBSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ExerciseCollectionName { get; set; } = null!;

        public string TestCollectionName { get; set; } = null!;

        public string VerifiedTestCollectionName { get; set; } = null!;
    }
}
