using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Core.Entities;
using Core.Interfaces;

namespace Application.Services
{
    internal class OwnerService : IOwnerService
    {
        private readonly IUnitOfWork unitOfWork;

        public OwnerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task CreateAsync(OwnerDto dto)
        {
            var owner = new Owner
            {
                FullName = dto.FullName,
                profile = dto.Profile,
                Avatar = dto.Avatar,

                Address = new Address
                {
                    Number = dto.Address.Number,
                    Street = dto.Address.Street,
                    City = dto.Address.City
                },

                PortfolioItems = dto.Projects.Select(p => new PortfolioItem
                {
                    ProjectName = p.ProjectName,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description
                }).ToList()
            };

            await unitOfWork.Owners.InsertAsync(owner);
            await unitOfWork.SaveAsync();
        }

        public Task<IEnumerable<OwnerDto>> GetAllProjects()
        {
           
        }

        public Task<OwnerDto?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
