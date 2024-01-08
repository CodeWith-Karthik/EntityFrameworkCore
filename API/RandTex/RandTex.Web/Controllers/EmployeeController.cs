﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandTex.Application.DTO.Employee;
using RandTex.Application.ViewModels;
using RandTex.DataAccess.Common;
using RandTex.Domain.Models;

namespace RandTex.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var employees = await _dbContext.Employee.ToListAsync();

            return Ok(employees);
        }

        [HttpGet]
        [Route("ListWithDetails")]
        public async Task<ActionResult> GetDetails()
        {
            var employees = await _dbContext.Employee.Include(x=>x.Department).Include(x=>x.EmployeeDetails).ToListAsync();

            var empMapped = _mapper.Map<List<EmployeeDetailsVM>>(employees);

            return Ok(empMapped);
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

        [HttpGet]
        [Route("FilterByYearAndDepartment")]
        public async Task<ActionResult> GetEmployeeByFilter(int year,int departmentId)
        {
            //var employee = await _dbContext.Employee.FirstAsync();

            //var employee = await _dbContext.Employee.FirstAsync(x=>x.EmployedFrom == year);

            //var employee = await _dbContext.Employee.FirstOrDefaultAsync(x => x.EmployedFrom == year);

            var employee = await _dbContext.Employee.Where(x => x.EmployedFrom == year && x.DepartmentId == departmentId).ToListAsync();

            if (employee == null)
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
