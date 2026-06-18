namespace Application.DTOs.OwnerDTOs
{
    public class OwnerDto
    {
        public required string FullName { get; set; }
        public required string Profile { get; set; }
        public string? Avatar { get; set; }

        public required AddressDto Address { get; set; }

        public List<PortfolioItemDto> Projects { get; set; } = [];
    }

}