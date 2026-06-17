namespace Core.Entities
{
    public class Owner : EntityBase
    {
        public required string FullName { get; set; }
        public required string profile { get; set; }
        public string? Avatar { get; set; }

        public Guid AddressId { get; set; }
        public Address Address { get; set; } = null!;

        public ICollection<PortfolioItem> PortfolioItems { get; set; } = new List<PortfolioItem>();

    }
}
