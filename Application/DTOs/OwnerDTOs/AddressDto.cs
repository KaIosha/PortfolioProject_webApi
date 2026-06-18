namespace Application.DTOs.OwnerDTOs
{
    public class AddressDto
    {
        public int? Number { get; set; }
        public string? Street { get; set; }
        public required string City { get; set; }
    }
}