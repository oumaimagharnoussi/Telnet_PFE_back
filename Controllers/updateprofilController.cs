using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticketback.Context;
using Ticketback.Models;

namespace Ticketback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class updateprofilController : ControllerBase
    {

        private readonly AppDbContext _authContext;
        private readonly IConfiguration _configuration;
       
        public updateprofilController(IConfiguration configuration, AppDbContext appDbContext)
        {
            _configuration = configuration;
            _authContext = appDbContext;
            
        }

        [HttpPut]
        [Route("{userId:int}")]
        public async Task<IActionResult> UpdateProfile([FromRoute] int userId, UpdateUserRequest updateUserRequest)
        {
            var user = await _authContext.Users.FindAsync(userId);
            if (User != null)
            {
                user.userNumber = updateUserRequest.userNumber;
                user.firstName = updateUserRequest.firstName;
                user.lastName = updateUserRequest.lastName;
                user.userName = updateUserRequest.userName;
                
                user.picture = updateUserRequest.picture;
               
                user.email = updateUserRequest.email;
               
                await _authContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }
    }
}
