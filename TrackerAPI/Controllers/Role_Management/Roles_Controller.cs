using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLayer.Application_View_Entities.Response_View_Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TrackerAPI.Controllers.Role_Management
{
	[Route("api/[controller]")]
	[ApiController]
	public class Roles_Controller : ControllerBase
	{
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public Roles_Controller(RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Create([Required] string RoleName)
        {
            if (ModelState.IsValid)
            {
                var RoleExists = await _roleManager.FindByNameAsync(RoleName);
                if (RoleExists != null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response_VE { Status = "Error", Message = "Role already exists!" });

                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(RoleName));
                if (!result.Succeeded)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response_VE { Status = "Error", Message = "Role creation failed! Please check Role Name and try again." });
            }
            return Ok(new Response_VE { Status = "Success", Message = "Role created successfully!" });
        }
    }

    
}
