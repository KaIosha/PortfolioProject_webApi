namespace Application.DTOs.ProjectDTos
{
    public class CreateProjectDto
    {
        public Guid OwnerId { get; set; }

        public required string ProjectName { get; set; }
        public required string ImageUrl { get; set; }
        public required string Description { get; set; }
    }
}
