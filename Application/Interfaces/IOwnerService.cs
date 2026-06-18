using Application.DTOs.OwnerDTOs;

namespace Application.Interfaces
{
    public interface IOwnerService
    {

        Task<OwnerDto?> GetOwnerWithDetailsAsync(Guid id);
        Task<IEnumerable<PortfolioItemDto>> GetProjectsAsync(Guid ownerId);

        Task<Guid> CreateAsync(CreateOwnerDto dto);

        Task UpdateAsync(Guid id, UpdateOwnerDto dto);

        Task DeleteAsync(Guid id);
    }
}
