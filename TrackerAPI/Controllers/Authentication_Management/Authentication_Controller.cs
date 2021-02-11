using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Application_View_Entities.Login_View_Entities;
using ApplicationLayer.Application_View_Entities.Registration_View_Entities;
using ApplicationLayer.Application_View_Entities.Response_View_Entities;
using DomainLayer.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace TrackerAPI.Controllers.Authentication_Management
{
	[Route("api/[controller]")]
	[ApiController]
	public class Authentication_Controller : ControllerBase
	{
        private readonly UserManager<Application_User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public Authentication_Controller(UserManager<Application_User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
		{
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login_VE model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    Rolename=userRoles[0]
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Registration_VE model)
        {
            try
            {
                var userExists = await _userManager.FindByNameAsync(model.Username);
                if (userExists != null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response_VE { Status = "Error", Message = "User already exists!" });

                Application_User user = new Application_User()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Username
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response_VE { Status = "Error", Message = "User creation failed! Please check user details and try again." });

                }
                else
                {
                    var roleresult = await _userManager.AddToRoleAsync(user, "Customer");
                }
                return Ok(new Response_VE { Status = "Success", Message = "User created successfully!" });
            }
            catch (Exception Exc)
            {

                throw Exc;
            }

        }

        [HttpPost]
        [Route("register_admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] Registration_VE model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response_VE { Status = "Error", Message = "User already exists!" });

            Application_User user = new Application_User()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response_VE { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await _roleManager.RoleExistsAsync(User_Roles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(User_Roles.Admin));
            if (!await _roleManager.RoleExistsAsync(User_Roles.User))
                await _roleManager.CreateAsync(new IdentityRole(User_Roles.User));

            if (await _roleManager.RoleExistsAsync(User_Roles.Admin))
            {
                await _userManager.AddToRoleAsync(user, User_Roles.Admin);
            }

            return Ok(new Response_VE { Status = "Success", Message = "User created successfully!" });
        }
    }
}
