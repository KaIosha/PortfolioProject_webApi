using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.ProjectDTos;
using Application.Interfaces;
using Core.Entities;
using Core.Interfaces;

namespace Application.Services.ProjectServices
{

    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Guid> CreateAsync(CreateProjectDto dto)
        {
            var owner = await unitOfWork.SpecificOwners.GetByIdAsync(dto.OwnerId);

            if (owner == null)
                throw new Exception("Owner not found");

            var project = new PortfolioItem
            {
                ProjectName = dto.ProjectName,
                ImageUrl = dto.ImageUrl,
                Description = dto.Description,
                OwnerId = dto.OwnerId
            };

            await unitOfWork.PortfolioItems.InsertAsync(project);
            await unitOfWork.SaveAsync();

            return project.Id;
        }

        public async Task UpdateAsync(Guid id, UpdateProjectDto dto)
        {
            var project = await unitOfWork.PortfolioItems.GetByIdAsync(id);

            if (project == null)
                throw new Exception("Project not found");

            project.ProjectName = dto.ProjectName;
            project.ImageUrl = dto.ImageUrl;
            project.Description = dto.Description;

            unitOfWork.PortfolioItems.Update(project);

            await unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await unitOfWork.PortfolioItems.DeleteAsync(id);
            await unitOfWork.SaveAsync();
        }
    }
}

