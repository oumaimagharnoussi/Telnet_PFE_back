using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticketback.Context;
using Ticketback.Models;

namespace Ticketback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkFromHomeRequestController : ControllerBase
    {
        private readonly AppDbContext _authContext;

        public WorkFromHomeRequestController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<WorkFromHomeRequest>> GetAllWorkFromHomeRequests()
        {
            return Ok(await _authContext.WorkFromHomeRequests.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkFromHomeRequest(AddWorkFromHomeRequest addWorkFromHomeRequest)
        {
            var user = await _authContext.Users.FindAsync(addWorkFromHomeRequest.userId);

            var workFromHomeRequest = new WorkFromHomeRequest()
            {
                userId = addWorkFromHomeRequest.userId,
                User = user,
                //activityName = addWorkFromHomeRequest.activityName,
                startDate = addWorkFromHomeRequest.startDate,
                endDate = addWorkFromHomeRequest.endDate,
                motive = addWorkFromHomeRequest.motive,
                state = addWorkFromHomeRequest.state,
                dayNumber = addWorkFromHomeRequest.dayNumber,
                halfDay = addWorkFromHomeRequest.halfDay,
            };

            // Use the getters to set the values of userNumber and userFullName
            var workFromHomeUserNumber = workFromHomeRequest.userNumber;
            var userFullName = workFromHomeRequest.userFullName;

            await _authContext.WorkFromHomeRequests.AddAsync(workFromHomeRequest);
            await _authContext.SaveChangesAsync();

            return Ok(workFromHomeRequest);
        }


        [HttpPut]
        [Route("{workHomeRequestId:int}")]
        public async Task<IActionResult> UpdateWorkFromHomeRequest([FromRoute] int workHomeRequestId, UpdateWorkFromHomeRequest updateWorkFromHomeRequest)
        {
            var workFromHomeRequest = await _authContext.WorkFromHomeRequests.FindAsync(workHomeRequestId);
            if (workFromHomeRequest != null)
            {
                workFromHomeRequest.userId = updateWorkFromHomeRequest.userId;
               // workFromHomeRequest.activityName = updateWorkFromHomeRequest.activityName;
                workFromHomeRequest.startDate = updateWorkFromHomeRequest.startDate;
                workFromHomeRequest.endDate = updateWorkFromHomeRequest.endDate;
                workFromHomeRequest.motive = updateWorkFromHomeRequest.motive;
                workFromHomeRequest.state = updateWorkFromHomeRequest.state;
                workFromHomeRequest.dayNumber = updateWorkFromHomeRequest.dayNumber;
                workFromHomeRequest.halfDay = updateWorkFromHomeRequest.halfDay;

                await _authContext.SaveChangesAsync();
                return Ok(workFromHomeRequest);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{workHomeRequestId:int}")]
        public async Task<IActionResult> GetWorkFromHomeRequest([FromRoute] int workHomeRequestId)
        {
            var workFromHomeRequest = await _authContext.WorkFromHomeRequests.FindAsync(workHomeRequestId);
            if (workFromHomeRequest == null)
            {
                return NotFound();
            }
            return Ok(workFromHomeRequest);

        }

        [HttpDelete]
        [Route("{workHomeRequestId:int}")]
        public async Task<IActionResult> DeleteWorkFromHomeRequest([FromRoute] int workHomeRequestId)
        {
            var workFromHomeRequest = await _authContext.WorkFromHomeRequests.FindAsync(workHomeRequestId);
            if (workFromHomeRequest != null)
            {
                _authContext.Remove(workFromHomeRequest);
                await _authContext.SaveChangesAsync();
                return Ok(workFromHomeRequest);
            }
            return NotFound();
        }


    }
}
