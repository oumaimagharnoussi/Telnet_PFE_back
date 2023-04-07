/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticketback.Context;
using Ticketback.Models;

namespace Ticketback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly AppDbContext _authContext;

        public GroupsController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }


        [HttpGet]
        public async Task<ActionResult<Groups>> GetAllGroupss()
        {
            return Ok(await _authContext.Groupss.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddGroups(AddGroupsRequest addGroupsRequest)
        {
            var groups = new Groups()
            {

                libelle = addGroupsRequest.libelle,

            };

            await _authContext.Groupss.AddAsync(groups);
            await _authContext.SaveChangesAsync();



            return Ok(groups);
        }

        [HttpPut]
        [Route("{groupId:int}")]
        public async Task<IActionResult> UpdateGroups([FromRoute] int groupId, UpdateGroupsRequest updateGroupsRequest)
        {
            var groups = await _authContext.Groupss.FindAsync(groupId);
            if (groups != null)
            {
                groups.libelle = updateGroupsRequest.libelle;

                await _authContext.SaveChangesAsync();
                return Ok(groups);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{groupId:int}")]
        public async Task<IActionResult> GetGroups([FromRoute] int groupId)
        {
            var groups = await _authContext.Groupss.FindAsync(groupId);
            if (groups == null)
            {
                return NotFound();
            }
            return Ok(groups);

        }

        [HttpDelete]
        [Route("{groupId:int}")]
        public async Task<IActionResult> DeleteGroups([FromRoute] int groupId)
        {
            var groups = await _authContext.Groupss.FindAsync(groupId);
            if (groups != null)
            {
                _authContext.Remove(groups);
                await _authContext.SaveChangesAsync();
                return Ok(groups);
            }
            return NotFound();
        }
    }
}*/
