using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticketback.Context;
using Ticketback.Models;

namespace Ticketback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupeController : ControllerBase
    {
        private readonly AppDbContext _authContext;

        public GroupeController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }
        [HttpGet]
        public async Task<ActionResult<Groupe>> GetAllGroupes()
        {
            return Ok(await _authContext.Groupes.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddGroupe(AddGroupeRequest addGroupeRequest)
        {
            var groupe = new Groupe()
            {

                libelle = addGroupeRequest.libelle,
                Users = addGroupeRequest.Users,

            };

            await _authContext.Groupes.AddAsync(groupe);
            await _authContext.SaveChangesAsync();



            return Ok(groupe);
        }
        [HttpPut]
        [Route("{groupId:int}")]
        public async Task<IActionResult> UpdateGroupe([FromRoute] int groupId, UpdateGroupeRequest updateGroupeRequest)
        {
            var groupe = await _authContext.Groupes.FindAsync(groupId);
            if (groupe != null)
            {
                groupe.libelle = updateGroupeRequest.libelle;
                groupe.Users = updateGroupeRequest.Users;

                await _authContext.SaveChangesAsync();
                return Ok(groupe);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("{groupId:int}")]
        public async Task<IActionResult> GetGroupe([FromRoute] int groupId)
        {
            var groupe = await _authContext.Groupes.FindAsync(groupId);
            if (groupe == null)
            {
                return NotFound();
            }
            return Ok(groupe);

        }
        [HttpDelete]
        [Route("{groupId:int}")]
        public async Task<IActionResult> DeleteGroupe([FromRoute] int groupId)
        {
            var groupe = await _authContext.Groupes.FindAsync(groupId);
            if (groupe != null)
            {
                _authContext.Remove(groupe);
                await _authContext.SaveChangesAsync();
                return Ok(groupe);
            }
            return NotFound();
        }

    }
}
