using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Text;
using Ticketback.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.Runtime.InteropServices;
using System.Data;
using System.Net.Http.Headers;
using Ticketback.Models;
using Ticketback.Helpers;
using System.Security.Cryptography;
using Ticketback.UtilityService;
using Ticketback.Migrations;

namespace Ticketback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangePasswordController : ControllerBase
    {
        private readonly AppDbContext _authContext;
        private readonly IConfiguration _configuration;
        
        public ChangePasswordController(IConfiguration configuration, AppDbContext appDbContext)
        {
            _configuration = configuration;
            _authContext = appDbContext;
            
        }

        [HttpPut]
        [Route("{userId:int}")]
        public async Task<IActionResult> UpdateUserPass([FromRoute] int userId, UpdateUserRequest updateUserRequest)
        {
            var user = await _authContext.Users.FindAsync(userId);
            if (User != null)
            {

                user.userPassword = updateUserRequest.userPassword;
                user.userPassword = PasswordHasher.HashPassword(user.userPassword);
                await _authContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }
    }
}
