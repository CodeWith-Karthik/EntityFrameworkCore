using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandTex.Application.DTO.Employee;
using RandTex.DataAccess.Common;
using RandTex.Domain.Models;

namespace RandTex.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var employees = await _dbContext.Employee.ToListAsync();

            return Ok(employees);
        }

        [HttpGet]
        [Route("ByEmployeeId")]
        public async Task<ActionResult> Get(int employeeId)
        {
            var employee = await _dbContext.Employee.FirstOrDefaultAsync(x=>x.Id == employeeId);

            if(employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateEmployeeDto employeeDto)
        {
            Employee employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                MiddleName = employeeDto.MiddleName,
                LastName = employeeDto.LastName,
                DepartmentId = employeeDto.DepartmentId,
                EmployedFrom = employeeDto.EmployedFrom
            };

            _dbContext.Employee.Add(employee);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }


        [HttpPut]
        public async Task<ActionResult> Update(UpdateEmployeeDto employeeDto)
        {
            var employeeFromDb = _dbContext.Employee.AsNoTracking().Where(x=>x.Id == employeeDto.Id).FirstOrDefault();

            if(employeeFromDb == null)
            {
                return BadRequest("Invalid Employee Id");
            }

            Employee employee = new Employee
            {
                Id = employeeDto.Id,
                FirstName = employeeDto.FirstName,
                MiddleName = employeeDto.MiddleName,
                LastName = employeeDto.LastName,
                DepartmentId = employeeDto.DepartmentId,
                EmployedFrom = employeeDto.EmployedFrom
            };

            _dbContext.Employee.Update(employee);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int employeeId)
        {
            var employeeFromDb = _dbContext.Employee.Where(x => x.Id == employeeId).FirstOrDefault();

            if (employeeFromDb == null)
            {
                return NotFound();
            }

            _dbContext.Employee.Remove(employeeFromDb);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
