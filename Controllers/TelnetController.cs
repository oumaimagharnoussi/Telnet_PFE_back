using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticketback.Context;
using Ticketback.Models;

namespace Ticketback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelnetController : ControllerBase
    {
        private readonly AppDbContext _authContext;

        public TelnetController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }
        [HttpGet]
        public async Task<ActionResult<Telnet>> GetAllTelnetes()
        {
            return Ok(await _authContext.Telnet.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddTelnet(AddTelnetRequest addTelnetRequest)
        {
            var telnet = new Telnet()
            {

                libelle = addTelnetRequest.libelle,
                Users = addTelnetRequest.Users,

            };

            await _authContext.Telnet.AddAsync(telnet);
            await _authContext.SaveChangesAsync();



            return Ok(telnet);
        }
        [HttpPut]
        [Route("{telnetId:int}")]
        public async Task<IActionResult> UpdateTelnet([FromRoute] int telnetId, UpdateTelnetRequest updateTelnetRequest)
        {
            var telnet = await _authContext.Telnet.FindAsync(telnetId);
            if (telnet != null)
            {
                telnet.libelle = updateTelnetRequest.libelle;
                telnet.Users = updateTelnetRequest.Users;

                await _authContext.SaveChangesAsync();
                return Ok(telnet);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("{telnetId:int}")]
        public async Task<IActionResult> GetTelnet([FromRoute] int telnetId)
        {
            var telnet = await _authContext.Telnet.FindAsync(telnetId);
            if (telnet == null)
            {
                return NotFound();
            }
            return Ok(telnet);

        }
        [HttpDelete]
        [Route("{telnetId:int}")]
        public async Task<IActionResult> DeleteTelnet([FromRoute] int telnetId)
        {
            var telnet = await _authContext.Telnet.FindAsync(telnetId);
            if (telnet != null)
            {
                _authContext.Remove(telnet);
                await _authContext.SaveChangesAsync();
                return Ok(telnet);
            }
            return NotFound();
        }
    }
}
