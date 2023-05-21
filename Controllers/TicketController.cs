using Microsoft.AspNetCore.Mvc;

using Ticketback.Context;
using Microsoft.EntityFrameworkCore;
using Ticketback.Models;
using Ticketback.Helpers;

using Ticketback.UtilityService;



namespace Ticketback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly AppDbContext _authContext;
        private readonly IConfiguration _configuration;
        private readonly IEmailService emailService;

        public TicketController(IConfiguration configuration, AppDbContext appDbContext, IEmailService service)
        {
            _configuration = configuration;
            _authContext = appDbContext;
            this.emailService = service;
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

            int dayNumber = CalculateBetweenDates(addTicketRequest.startDate, addTicketRequest.endDate);
            ticket.dayNumber = dayNumber;



            await _authContext.Tickets.AddAsync(ticket);
            await _authContext.SaveChangesAsync();
            // Send email
            await SendMail();


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
                ticket.telnetId = updateTicketRequest.telnetId;

                int dayNumber = CalculateBetweenDates(updateTicketRequest.startDate, updateTicketRequest.endDate);
                ticket.dayNumber = dayNumber;

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


        [HttpGet]
        [Route("{ticketId:int}/commentaires")]
        public async Task<IActionResult> GetTicketCommentaires([FromRoute] int ticketId)
        {
            var commentaires = await _authContext.Commentaires
                .Where(c => c.ticketId == ticketId)
                .ToListAsync();

            if (commentaires == null || commentaires.Count == 0)
            {
                return NotFound();
            }

            return Ok(commentaires);
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
        [HttpPost("SendMail")]
        public async Task<IActionResult> SendMail()
        {
            try
            {
                Mailrequest mailrequest = new Mailrequest
                {
                    ToEmail = "omaymagharnoussi@gmail.com",
                    Subject = "Successful Ticket Creation Confirmation",
                    Body = @"<html>
            <head>
            </head>
            <body>
               <div>
                <div>
                 <div>
                   <h1>We are pleased to inform you that your ticket has been successfully created.</h1>
                   <hr>
                   <p>We have taken your request into account and our team will review it as soon as possible. We will keep you informed of the progress of your request and we will do our best to resolve your problem or respond to your request as soon as possible.</p>
                   
                 
                   <p> Best regards,<br><br> Telnet Holding </p>
                </div>
               </div>
              </div>

            </body >
            </html > "

                };

                await emailService.SendEmailAsync(mailrequest);

                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}