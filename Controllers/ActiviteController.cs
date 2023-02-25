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
        public async Task<ActionResult<Activite>> GetAllActivites()
        {
            return Ok(await _authContext.Activites.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddActivite(AddActiviteRequest addActiviteRequest)
        {
            var activite = new Activite()
            {

                libelle = addActiviteRequest.libelle,

            };

            await _authContext.Activites.AddAsync(activite);
            await _authContext.SaveChangesAsync();



            return Ok(activite);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateActivite([FromRoute] int id, UpdateActiviteRequest updateActiviteRequest)
        {
            var activite = await _authContext.Activites.FindAsync(id);
            if (activite != null)
            {
                activite.libelle = updateActiviteRequest.libelle;

                await _authContext.SaveChangesAsync();
                return Ok(activite);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetActivite([FromRoute] int id)
        {
            var activite = await _authContext.Activites.FindAsync(id);
            if (activite == null)
            {
                return NotFound();
            }
            return Ok(activite);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteActivite([FromRoute] int id)
        {
            var activite = await _authContext.Activites.FindAsync(id);
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
