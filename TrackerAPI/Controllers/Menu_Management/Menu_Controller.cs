using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLayer.Application_Services.Menu_Management;
using ApplicationLayer.Application_View_Entities.Menu_View_Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrackerAPI.Controllers.Menu_Management
{
	[Route("api/[controller]")]
	[ApiController]
	public class Menu_Controller : ControllerBase
	{
		private readonly IMenu_Service _menu_Service;

		public Menu_Controller(IMenu_Service menu_Service)
		{
			_menu_Service = menu_Service;
		}

		[HttpGet("GetAllMenus")]
		public async Task<IActionResult> GetAllMenus()
		{
			var GetMenus =await _menu_Service.GetAllMenus();
			return Ok(GetMenus);
		}

		[HttpGet("GetAllMenusByUserRole/UserRole")]
		public async Task<IActionResult> GetAllMenusByUserRole(string UserRole)
		{
			var GetMenus = await _menu_Service.GetAllMenusByRole(UserRole);
			return Ok(GetMenus);
		}

		[HttpPost("AddRolesToMenus")]
		public async Task<IActionResult> AddRolesToMenus(List<MenusRolesMap_VE> menusRolesMap_VEs)
		{
			var GetMenus = await _menu_Service.AddRolesToMenus(menusRolesMap_VEs);
			return Ok(GetMenus);
		}

		[HttpPost("CreateNewMenus")]
		public async Task<IActionResult> CreateNewMenus(List<MenusList_VE> menusList_VEs)
		{
			var GetMenus = await _menu_Service.CreateNewMenus(menusList_VEs);
			return Ok(GetMenus);
		}
	}
}
