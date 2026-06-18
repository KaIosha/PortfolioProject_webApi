using Application.DTOs.OwnerDTOs;
using Application.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers.Owner
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService service;

        public OwnerController(IOwnerService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OwnerDto>> GetOwnerFullDetails(Guid id)
        {
            var Owner = await service.GetOwnerWithDetailsAsync(id);

            if (Owner == null)
                return NotFound();

            return Ok(Owner);
        }

        [HttpPost]
        public async Task<ActionResult<OwnerDto>> CreateOwner([FromBody] CreateOwnerDto ownerDto)
        {
            var createdId = await service.CreateAsync(ownerDto);
            return CreatedAtAction(
              nameof(GetOwnerFullDetails),
                 new { id = createdId },
                      null
          );
        }

        // PUT: api/owners/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateOwner(Guid id, [FromBody] UpdateOwnerDto dto)
        {
            await service.UpdateAsync(id, dto);

            return NoContent();
        }

        // DELETE: api/owners/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {
            await service.DeleteAsync(id);

            return NoContent();
        }
    }
}
