using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticketback.Context;
using Ticketback.Models;

namespace Ticketback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtatController : ControllerBase
    {
        private readonly AppDbContext _authContext;
  
        public EtatController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }


        [HttpGet]
        public async Task<ActionResult<Etat>> GetAllEtats()
        {
            return Ok(await _authContext.Etats.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddEtat(AddEtatRequest addEtatRequest)
        {
            var etat = new Etat()
            {

                libelle = addEtatRequest.libelle,
                
            };
            
            await _authContext.Etats.AddAsync(etat);
            await _authContext.SaveChangesAsync();



            return Ok(etat);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEtat([FromRoute] int id, UpdateEtatRequest updateEtatRequest)
        {
            var etat = await _authContext.Etats.FindAsync(id);
            if (etat != null)
            {
                etat.libelle = updateEtatRequest.libelle;
                
                await _authContext.SaveChangesAsync();
                return Ok(etat);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetEtat([FromRoute] int id)
        {
            var etat = await _authContext.Etats.FindAsync(id);
            if (etat == null)
            {
                return NotFound();
            }
            return Ok(etat);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEtat([FromRoute] int id)
        {
            var etat = await _authContext.Etats.FindAsync(id);
            if (etat != null)
            {
                _authContext.Remove(etat);
                await _authContext.SaveChangesAsync();
                return Ok(etat);
            }
            return NotFound();
        }
    }
}
