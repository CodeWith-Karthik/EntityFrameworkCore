using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandTex.Application.DTO.Department;
using RandTex.DataAccess.Common;
using RandTex.Domain.Models;

namespace RandTex.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var departments = await _dbContext.Department.ToListAsync();

            return Ok(departments);
        }

        [HttpGet]
        [Route("ByDepartmentId")]
        public async Task<ActionResult> Get(int departmentId)
        {
            var department = await _dbContext.Department.FirstOrDefaultAsync(x=>x.Id == departmentId);

            if(department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateDepartmentDto departmentDto)
        {
            Department department = new Department
            {
                Name = departmentDto.Name
            };

            _dbContext.Department.Add(department);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }


        [HttpPut]
        public async Task<ActionResult> Update(UpdateDepartmentDto departmentDto)
        {
            var departmentFromDb = _dbContext.Department.AsNoTracking().Where(x=>x.Id == departmentDto.Id).FirstOrDefault();

            if(departmentFromDb == null)
            {
                return BadRequest("Invalid Department Id");
            }

            Department department = new Department
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name,
            };

            _dbContext.Department.Update(department);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int departmentId)
        {
            var departmentFromDb = _dbContext.Department.Where(x => x.Id == departmentId).FirstOrDefault();

            if (departmentFromDb == null)
            {
                return NotFound();
            }

            _dbContext.Department.Remove(departmentFromDb);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
