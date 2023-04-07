using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticketback.Context;
using Ticketback.Models;

namespace Ticketback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitieController : ControllerBase
    {
        private readonly AppDbContext _authContext;

        public ActivitieController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }
        [HttpGet]
        public async Task<ActionResult<Activitie>> GetAllActivities()
        {
            return Ok(await _authContext.Activities.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddActivitie(AddActivitieRequest addActivitieRequest)
        {
            var activitie = new Activitie()
            {

                libelle = addActivitieRequest.libelle,

            };

            await _authContext.Activities.AddAsync(activitie);
            await _authContext.SaveChangesAsync();



            return Ok(activitie);
        }
        [HttpPut]
        [Route("{activityId:int}")]
        public async Task<IActionResult> UpdateActivitie([FromRoute] int activityId, UpdateActivitieRequest updateActivitieRequest)
        {
            var activitie = await _authContext.Activities.FindAsync(activityId);
            if (activitie != null)
            {
                activitie.libelle = updateActivitieRequest.libelle;

                await _authContext.SaveChangesAsync();
                return Ok(activitie);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("{activityId:int}")]
        public async Task<IActionResult> GetActivitie([FromRoute] int activityId)
        {
            var activitie = await _authContext.Activities.FindAsync(activityId);
            if (activitie == null)
            {
                return NotFound();
            }
            return Ok(activitie);

        }
        [HttpDelete]
        [Route("{activityId:int}")]
        public async Task<IActionResult> DeleteActivitie([FromRoute] int activityId)
        {
            var activitie = await _authContext.Activities.FindAsync(activityId);
            if (activitie != null)
            {
                _authContext.Remove(activitie);
                await _authContext.SaveChangesAsync();
                return Ok(activitie);
            }
            return NotFound();
        }



    }
}
