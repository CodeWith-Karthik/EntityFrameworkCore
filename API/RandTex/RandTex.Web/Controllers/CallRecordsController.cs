using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandTex.Application.DTO.CallRecords;
using RandTex.DataAccess.Common;
using RandTex.Domain.Models;

namespace RandTex.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallRecordsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CallRecordsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var callRecordss = await _dbContext.CallRecords.ToListAsync();

            return Ok(callRecordss);
        }

        [HttpGet]
        [Route("ByCallRecordsId")]
        public async Task<ActionResult> Get(int callRecordsId)
        {
            var callRecords = await _dbContext.CallRecords.FirstOrDefaultAsync(x=>x.Id == callRecordsId);

            if(callRecords == null)
            {
                return NotFound();
            }

            return Ok(callRecords);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCallRecordsDto callRecordsDto)
        {
            CallRecords callRecords = new CallRecords
            {
               StartTime = callRecordsDto.StartTime,
               EndTime = callRecordsDto.EndTime,
               CallType = callRecordsDto.CallType,
               EmployeeId = callRecordsDto.EmployeeId,
               CustomerId = callRecordsDto.CustomerId

            };

            _dbContext.CallRecords.Add(callRecords);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }


        [HttpPut]
        public async Task<ActionResult> Update(UpdateCallRecordsDto callRecordsDto)
        {
            var callRecordsFromDb = _dbContext.CallRecords.AsNoTracking().Where(x=>x.Id == callRecordsDto.Id).FirstOrDefault();

            if(callRecordsFromDb == null)
            {
                return BadRequest("Invalid CallRecords Id");
            }

            CallRecords callRecords = new CallRecords
            {
                Id = callRecordsDto.Id,
                StartTime = callRecordsDto.StartTime,
                EndTime = callRecordsDto.EndTime,
                CallType = callRecordsDto.CallType,
                EmployeeId = callRecordsDto.EmployeeId,
                CustomerId = callRecordsDto.CustomerId
            };

            _dbContext.CallRecords.Update(callRecords);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int callRecordsId)
        {
            var callRecordsFromDb = _dbContext.CallRecords.Where(x => x.Id == callRecordsId).FirstOrDefault();

            if (callRecordsFromDb == null)
            {
                return NotFound();
            }

            _dbContext.CallRecords.Remove(callRecordsFromDb);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
