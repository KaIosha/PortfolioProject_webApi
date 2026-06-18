using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.ProjectDTos;

namespace Application.Interfaces
{
    public interface IProjectService
    {
        Task<Guid> CreateAsync(CreateProjectDto dto);
        Task UpdateAsync(Guid id, UpdateProjectDto dto);
        Task DeleteAsync(Guid id);
    }
}
