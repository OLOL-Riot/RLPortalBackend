namespace RLPortalBackend.Models
{
    /// <summary>
    /// MongoDB settings
    /// </summary>
    public class PortalGeographyMongoDBSettings
    {
        /// <summary>
        /// Connection string
        /// </summary>
        public string ConnectionString { get; set; } = null!;

        /// <summary>
        /// Database name
        /// </summary>
        public string DatabaseName { get; set; } = null!;

        /// <summary>
        /// Exercise collection name
        /// </summary>
        public string ExerciseCollectionName { get; set; } = null!;

        /// <summary>
        /// Test collection name
        /// </summary>
        public string TestCollectionName { get; set; } = null!;

        public string VerifiedTestCollectionName { get; set; } = null!;

        public string TheoryCollectionName { get; set; } = null!;

    }
}
