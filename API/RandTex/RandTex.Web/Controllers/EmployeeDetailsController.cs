using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandTex.Application.DTO.Department;
using RandTex.Application.DTO.EmployeeDetails;
using RandTex.DataAccess.Common;
using RandTex.Domain.Models;

namespace RandTex.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeDetailsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var employeeDetails = await _dbContext.EmployeeDetails.ToListAsync();

            return Ok(employeeDetails);
        }

        [HttpGet]
        [Route("ByEmployeeDetailsId")]
        public async Task<ActionResult> Get(int employeeDetailsId)
        {
            var department = await _dbContext.EmployeeDetails.FirstOrDefaultAsync(x=>x.Id == employeeDetailsId);

            if(department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateEmployeeDetailsDto employeeDetailsDto)
        {
            EmployeeDetails employeeDetails = new EmployeeDetails
            {
                EmployeeId = employeeDetailsDto.EmployeeId,
                Age = employeeDetailsDto.Age,
                Gender = employeeDetailsDto.Gender,
                PhoneNo = employeeDetailsDto.PhoneNo,
                EmailAddress = employeeDetailsDto.EmailAddress,
                Address = employeeDetailsDto.Address
            };

            _dbContext.EmployeeDetails.Add(employeeDetails);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }


        [HttpPut]
        public async Task<ActionResult> Update(UpdateEmployeeDetailsDto employeeDetailsDto)
        {
            var departmentFromDb = _dbContext.Department.AsNoTracking().Where(x=>x.Id == employeeDetailsDto.Id).FirstOrDefault();

            if(departmentFromDb == null)
            {
                return BadRequest("Invalid Employee Details Id");
            }

            EmployeeDetails employeeDetails = new EmployeeDetails
            {
                Id = employeeDetailsDto.Id,
                EmployeeId = employeeDetailsDto.EmployeeId,
                Age = employeeDetailsDto.Age,
                Gender = employeeDetailsDto.Gender,
                PhoneNo = employeeDetailsDto.PhoneNo,
                EmailAddress = employeeDetailsDto.EmailAddress,
                Address = employeeDetailsDto.Address
            };

            _dbContext.EmployeeDetails.Update(employeeDetails);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int employeeDetailsId)
        {
            var employeeDetailsFromDb = _dbContext.EmployeeDetails.Where(x => x.Id == employeeDetailsId).FirstOrDefault();

            if (employeeDetailsFromDb == null)
            {
                return NotFound();
            }

            _dbContext.EmployeeDetails.Remove(employeeDetailsFromDb);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
