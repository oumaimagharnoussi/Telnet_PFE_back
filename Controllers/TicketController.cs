using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticketback.Context;
using Ticketback.Migrations;
using Ticketback.Models;

namespace Ticketback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly AppDbContext _authContext;

        public TicketController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }
        [HttpGet]
        public async Task<ActionResult<Ticket>> GetAllTickets()
        {
            return Ok(await _authContext.Tickets.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddTicket(AddTicketRequest addTicketRequest)
        {
            var ticket = new Ticket()
            {
                // PrisEnChargePar = addTicketRequest.PrisEnChargePar,
                Priorite = addTicketRequest.Priorite,
                Type = addTicketRequest.Type,
                startDate = addTicketRequest.startDate,
                endDate = addTicketRequest.endDate,
                Description = addTicketRequest.Description,
                halfDay = addTicketRequest.halfDay,
                userId = addTicketRequest.userId,
                id = addTicketRequest.id,
                File = addTicketRequest.File,
                Commentaire = addTicketRequest.Commentaire,
                telnetId = addTicketRequest.telnetId
            };
            if (addTicketRequest.halfDay != HalfDay.Morning && addTicketRequest.halfDay != HalfDay.Afternoon)
            {
                int dayNumber = CalculateBetweenDates(addTicketRequest.startDate, addTicketRequest.endDate);
                ticket.dayNumber = dayNumber;
            }
            else
            {
                ticket.dayNumber = 0.5f;
                ticket.endDate = addTicketRequest.startDate;
            }

            await _authContext.Tickets.AddAsync(ticket);
            await _authContext.SaveChangesAsync();

            return Ok(ticket);
        }
        private int CalculateBetweenDates(DateTime startDate, DateTime endDate)
        {
            TimeSpan difference = endDate - startDate;
            int dayNumber = (int)Math.Ceiling(difference.TotalDays);
            return dayNumber;
        }

        [HttpPut]
        [Route("{ticketId:int}")]
        public async Task<IActionResult> UpdateTicket([FromRoute] int ticketId, UpdateTicketRequest updateTicketRequest)
        {
            var ticket = await _authContext.Tickets.FindAsync(ticketId);
            if (ticket != null)
            {
                ticket.Priorite = updateTicketRequest.Priorite;
                ticket.Type = updateTicketRequest.Type;
                ticket.startDate = updateTicketRequest.startDate;
                ticket.endDate = updateTicketRequest.endDate;
                ticket.Description = updateTicketRequest.Description;
                ticket.halfDay = updateTicketRequest.halfDay;
                ticket.userId = updateTicketRequest.userId;
                ticket.id = updateTicketRequest.id;
                ticket.dayNumber = updateTicketRequest.dayNumber;
                ticket.File = updateTicketRequest.File;
                ticket.Commentaire = updateTicketRequest.Commentaire;

                await _authContext.SaveChangesAsync();
                return Ok(ticket);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("{ticketId:int}")]
        public async Task<IActionResult> GetTicket([FromRoute] int ticketId)
        {
            var ticket = await _authContext.Tickets.FindAsync(ticketId);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);

        }
        [HttpDelete]
        [Route("{ticketId:int}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] int ticketId)
        {
            var ticket = await _authContext.Tickets.FindAsync(ticketId);
            if (ticket != null)
            {
                _authContext.Remove(ticket);
                await _authContext.SaveChangesAsync();
                return Ok(ticket);
            }
            return NotFound();
        }
    }
}
