using Application.DTOs.OwnerDTOs;
using Application.DTOs.ProjectDTos;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers.Projects
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService service;
        private readonly IOwnerService ownerService;

        public ProjectsController(IProjectService service,IOwnerService ownerService)
        {
            this.service = service;
            this.ownerService = ownerService;
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<PortfolioItemDto>>> GetProjects(Guid id)
        {

            var user = await ownerService.GetOwnerWithDetailsAsync(id);

            if (user == null)
                return NotFound();

            var projects = await ownerService.GetProjectsAsync(id);

            if (projects == null)
                return NotFound();

            return Ok(projects);
        }
        // POST: api/projects
        [HttpPost]
        public async Task<ActionResult> Create(CreateProjectDto dto)
        {
            var id = await service.CreateAsync(dto);
            return Ok();  
           
        }


        // PUT: api/projects/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateProjectDto dto)
        {
            await service.UpdateAsync(id, dto);
            return NoContent();
        }

        // DELETE: api/projects/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.DeleteAsync(id);
            return NoContent();
        }
    }
}
