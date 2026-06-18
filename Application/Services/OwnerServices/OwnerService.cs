using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.OwnerDTOs;
using Application.Interfaces;
using Core.Entities;
using Core.Interfaces;

namespace Application.Services.OwnerServices
{
    public class OwnerService : IOwnerService
    {
        private readonly IUnitOfWork unitOfWork;

        public OwnerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Guid> CreateAsync(CreateOwnerDto dto)
        {
            var NewOwner = new Owner
            {
                FullName = dto.FullName,
                profile = dto.Profile,
                Avatar = dto.Avatar,
                Address = new Address
                {
                    City = dto.Address.City
                    ,
                    Number = dto.Address.Number
                    ,
                    Street = dto.Address.Street
                },
                PortfolioItems = dto.Projects.Select(p => new PortfolioItem
                {
                    ProjectName = p.ProjectName,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description
                }).ToList()

            };
            await unitOfWork.Owners.InsertAsync(NewOwner);
            await unitOfWork.SaveAsync();
            return NewOwner.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var owner = await unitOfWork.Owners.GetByIdAsync(id);
            if (owner == null)
                throw new Exception("User Not Exsitssssssssss");

            await unitOfWork.Owners.DeleteAsync(id);
            await unitOfWork.SaveAsync();
        }



        public async Task<OwnerDto?> GetOwnerWithDetailsAsync(Guid id)
        {
            var owner = await unitOfWork.SpecificOwners.GetOwnerWithDetailsAsync(id);
            if (owner == null)
                return null;

            return new OwnerDto
            {
                FullName = owner.FullName,
                Profile = owner.profile,
                Avatar = owner.Avatar,
                Address = new AddressDto
                {
                    City = owner.Address.City,
                    Number = owner.Address.Number,
                    Street = owner.Address.Street

                },
                Projects = owner.PortfolioItems.Select(p => new PortfolioItemDto
                {
                    ProjectName = p.ProjectName,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl
                }).ToList()
            };
        }

            public async Task<IEnumerable<PortfolioItemDto>> GetProjectsAsync(Guid ownerId)
            {
                var owner = await unitOfWork.Owners.GetByIdAsync(ownerId);

                if (owner == null)
                    throw new Exception("The Owner isn't Exsist");

                return owner.PortfolioItems.Select(p => new PortfolioItemDto
                {
                    ProjectName = p.ProjectName,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description
                });
            }

        public async Task UpdateAsync(Guid id, UpdateOwnerDto dto)
        {
            var owner = await unitOfWork.Owners.GetByIdAsync(id);

            if (owner == null)
                throw new Exception("Owner not found");

            owner.FullName = dto.FullName;
            owner.profile = dto.Profile;
            owner.Avatar = dto.Avatar;

            unitOfWork.Owners.Update(owner);
            await unitOfWork.SaveAsync();


        }
    }
}
