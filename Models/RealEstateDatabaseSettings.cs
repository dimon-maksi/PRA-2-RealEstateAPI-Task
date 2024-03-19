namespace RealEstateAPI.Models
{
    public class RealEstateDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string RealEstateCollectionName { get; set; } = null!;
    }
}
