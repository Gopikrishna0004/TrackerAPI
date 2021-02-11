using ApplicationLayer.Application_View_Entities.Menu_View_Entities;
using ApplicationLayer.Application_View_Entities.Response_View_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Application_Services.Menu_Management
{
	public interface IMenu_Service
	{
		Task<List<MenusList_VE>> GetAllMenus();
		Task<List<MenusRolesMap_VE>> GetAllMenusByRole(string UserRole);
		Task<Response_VE> AddRolesToMenus(List<MenusRolesMap_VE> menuMaster_VEs);
		Task<Response_VE> CreateNewMenus(List<MenusList_VE> menusList_VEs);
	}
}
