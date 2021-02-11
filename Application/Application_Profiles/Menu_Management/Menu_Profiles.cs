using ApplicationLayer.Application_View_Entities.Menu_View_Entities;
using AutoMapper;
using DomainLayer.Table_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Application_Profiles.Menu_Management
{
	public class Menu_Profiles : Profile
	{
		public Menu_Profiles()
		{
			CreateMap<MenusList_VE, MenusList>();

			CreateMap<MenusList, MenusList_VE>();

			CreateMap<MenusRolesMap, MenusRolesMap_VE>();

			CreateMap<MenusRolesMap_VE, MenusRolesMap>();
		}
	}
}
