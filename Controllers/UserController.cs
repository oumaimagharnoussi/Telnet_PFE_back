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

namespace Ticketback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _authContext;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        public UserController(IConfiguration configuration, AppDbContext appDbContext, IEmailService emailService)
        {
            _configuration = configuration;
            _authContext = appDbContext;
            _emailService = emailService;
        }




        [HttpPost("authentificate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();
            var user = await _authContext.Users
                .FirstOrDefaultAsync(x => x.userNumber == userObj.userNumber);
            if (user == null)
                return NotFound(new { Message = "User Not Found!" });
            if (!PasswordHasher.VerifyPassword(userObj.userPassword, user.userPassword))
            {
                return BadRequest(new { Message = "Password is Incorrect" });
            }


            user.Token = CreateToken(user);
            //user.Token = CreateJwt(user);

            return Ok(new
            {
                Token = user.Token,
                Message = "Login Success!"
            });
            //return Ok(token);
        }

        //create token
        


        private string CreateToken(User user)
           {
               List<Claim> claims = new List<Claim>
       {
           new Claim(ClaimTypes.Role, user.Role),
           new Claim("name", user.userName),
           new Claim("lastname", user.lastName),
           new Claim("email", user.email),
           new Claim("activitie", user.activityId.ToString()),
           new Claim("usernmber", user.userNumber),
          // new Claim("activitie", user.Activitie?.libelle?.ToString()),

           new Claim("Groups", user.groupId.ToString())
       };



               var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                   _configuration.GetSection("AppSettings:Token").Value));

               var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

               var token = new JwtSecurityToken(
                   claims: claims,
                   expires: DateTime.Now.AddDays(1),
                   signingCredentials: creds);

               var jwt = new JwtSecurityTokenHandler().WriteToken(token);

               return jwt;
           }
          


        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();
            //check userNumber 
            if (await CheckUserNumberExistAsync(userObj.userNumber))
                return BadRequest(new { Message = "UserNumber Already Exist!" });
            //check username 
            if (await CheckUserNameExistAsync(userObj.userName))
                return BadRequest(new { Message = "Username Already Exist!" });
            //check email
            if (await CheckEmailExistAsync(userObj.email))
                return BadRequest(new { Message = "Email Already Exist!" });
            //check password
            var pass = CheckPasswordStrength(userObj.userPassword);
            if (!string.IsNullOrEmpty(pass))
                return BadRequest(new { Message = pass.ToString() });


            userObj.userPassword = PasswordHasher.HashPassword(userObj.userPassword);
            userObj.Role = "User";
            //userObj.Token = "";
            await _authContext.Users.AddAsync(userObj);
            await _authContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Registered!"
            });
        }

        private Task<bool> CheckUserNameExistAsync(string userName)
          => _authContext.Users.AnyAsync(x => x.userName == userName);
        private Task<bool> CheckUserNumberExistAsync(string userNumber)
         => _authContext.Users.AnyAsync(x => x.userNumber == userNumber);

        private Task<bool> CheckEmailExistAsync(string email)
          => _authContext.Users.AnyAsync(x => x.email == email);
        private string CheckPasswordStrength(string userPassword)
        {
            StringBuilder sb = new StringBuilder();
            if (userPassword.Length < 10)
                sb.Append("Minimum password lenght should be 10" + Environment.NewLine);
            if (!(Regex.IsMatch(userPassword, "[a-z]") && Regex.IsMatch(userPassword, "[A-Z]")
                && Regex.IsMatch(userPassword, "[0-9]")))
                sb.Append("Password should be Alphanumeric" + Environment.NewLine);
            if (!Regex.IsMatch(userPassword, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,`,-,=]"))
                sb.Append("Password should contain special chars" + Environment.NewLine);
            return sb.ToString();
        }

        //get all users
        [HttpGet]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            return Ok(await _authContext.Users.ToListAsync());
        }

        //crud
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequest addUserRequest)
        {
            var user = new User()
            {

                userNumber = addUserRequest.userNumber,
                firstName = addUserRequest.firstName,
                lastName = addUserRequest.lastName,
                userName = addUserRequest.userName,
                //userPassword = addUserRequest.userPassword,
                picture = addUserRequest.picture,
                qualification = addUserRequest.qualification,
                email = addUserRequest.email,
                //Role = addUserRequest.Role,
                //Token = addUserRequest.Token,
               // groupId = addUserRequest.groupId,
                
                activityId = addUserRequest.activityId
            };
            //user.userPassword = PasswordHasher.HashPassword(user.userPassword);
            await _authContext.Users.AddAsync(user);
            await _authContext.SaveChangesAsync();



            return Ok(user);
        }

        [HttpPut]
        [Route("{userId:int}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int userId, UpdateUserRequest updateUserRequest)
        {
            var user = await _authContext.Users.FindAsync(userId);
            if (User != null)
            {
                user.userNumber = updateUserRequest.userNumber;
                user.firstName = updateUserRequest.firstName;
                user.lastName = updateUserRequest.lastName;
                user.userName = updateUserRequest.userName;
                //user.userPassword = updateUserRequest.userPassword;
                user.picture = updateUserRequest.picture;
                user.qualification = updateUserRequest.qualification;
                user.email = updateUserRequest.email;
               // user.Role = updateUserRequest.Role;
                //user.Token = updateUserRequest.Token;
                user.activityId = updateUserRequest.activityId;
               // user.groupId = updateUserRequest.groupId;
                //user.Sites = updateUserRequest.Sites;

               // user.userPassword = PasswordHasher.HashPassword(user.userPassword);
                await _authContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{userId:int}")]
        public async Task<IActionResult> GetUser([FromRoute] int userId)
        {
            var user = await _authContext.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }

        [HttpDelete]
        [Route("{userId:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int userId)
        {
            var user = await _authContext.Users.FindAsync(userId);
            if (user != null)
            {
                _authContext.Remove(user);
                await _authContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }


        [HttpPost("send-reset-email/{email}")]
        public async Task<IActionResult> SendEmail(string email)
        {
            var user = await _authContext.Users.FirstOrDefaultAsync(a => a.email == email);
            if (user is null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "email Doesn't Exist"
                });
            }
            var tokenBytes = RandomNumberGenerator.GetBytes(64);
            var emailToken = Convert.ToBase64String(tokenBytes);
            user.ResetPasswordToken = emailToken;
            user.ResetPasswordExpiry = DateTime.Now.AddMinutes(15);
            string from = _configuration["EmailSettings: From"];
            var emailModel = new EmailModel(email, "Reset Password !!", EmailBody.EmailStringBody(email, emailToken));
            _emailService.SendEmail(emailModel);
            _authContext.Entry(user).State = EntityState.Modified;
            await _authContext.SaveChangesAsync();
            return Ok(new
            {
                StatusCode = 200,
                Message = "Email Sent!"
            });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            var newToken = resetPassword.EmailToken.Replace("+", "-");

            var user = await _authContext.Users.AsNoTracking().FirstOrDefaultAsync(a => a.email == resetPassword.email);
            if (user is null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "user Doesn't Exist"
                });
            }
            var tokenCode = user.ResetPasswordToken;
            DateTime emailTokenExpiry = user.ResetPasswordExpiry;
            if (tokenCode != resetPassword.EmailToken || emailTokenExpiry < DateTime.Now)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Invalid Reset Link"
                });
            }
            user.userPassword = PasswordHasher.HashPassword(resetPassword.NewPassword);
            _authContext.Entry(user).State = EntityState.Modified;
            await _authContext.SaveChangesAsync();
            return Ok(new
            {
                StatusCode = 200,
                Message = "Password Reset Successfully"
            });
        }
    }
}
