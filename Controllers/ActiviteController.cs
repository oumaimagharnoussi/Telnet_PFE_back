using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticketback.Context;
using Ticketback.Models;

namespace Ticketback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiviteController : ControllerBase
    {
        private readonly AppDbContext _authContext;

        public ActiviteController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }


        [HttpGet]
        public async Task<ActionResult<Activities>> GetAllActivites()
        {
            return Ok(await _authContext.Activites.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddActivite(AddActiviteRequest addActiviteRequest)
        {
            var activite = new Activities()
            {

                libelle = addActiviteRequest.libelle,

            };

            await _authContext.Activites.AddAsync(activite);
            await _authContext.SaveChangesAsync();



            return Ok(activite);
        }

        [HttpPut]
        [Route("{activityId:int}")]
        public async Task<IActionResult> UpdateActivite([FromRoute] int activityId, UpdateActiviteRequest updateActiviteRequest)
        {
            var activite = await _authContext.Activites.FindAsync(activityId);
            if (activite != null)
            {
                activite.libelle = updateActiviteRequest.libelle;

                await _authContext.SaveChangesAsync();
                return Ok(activite);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{activityId:int}")]
        public async Task<IActionResult> GetActivite([FromRoute] int activityId)
        {
            var activite = await _authContext.Activites.FindAsync(activityId);
            if (activite == null)
            {
                return NotFound();
            }
            return Ok(activite);

        }

        [HttpDelete]
        [Route("{activityId:int}")]
        public async Task<IActionResult> DeleteActivite([FromRoute] int activityId)
        {
            var activite = await _authContext.Activites.FindAsync(activityId);
            if (activite != null)
            {
                _authContext.Remove(activite);
                await _authContext.SaveChangesAsync();
                return Ok(activite);
            }
            return NotFound();
        }
    }
}
