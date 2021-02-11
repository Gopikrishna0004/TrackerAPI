using ApplicationLayer.Application_Repositories.EF_Repositories;
using ApplicationLayer.Application_View_Entities.Menu_View_Entities;
using ApplicationLayer.Application_View_Entities.Response_View_Entities;
using AutoMapper;
using DomainLayer.Table_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Application_Services.Menu_Management
{
	public class Menu_Service : IMenu_Service
	{
		private readonly IEFRepository _iEFRepository;
		private readonly IMapper _mapper;

		public Menu_Service(IEFRepository iEFRepository,IMapper mapper)
		{
			_iEFRepository = iEFRepository;
			_mapper = mapper;
		}

		public async Task<List<MenusList_VE>> GetAllMenus()
		{
			try
			{
				var GetMenus = await _iEFRepository.FindAll<MenusList>();
				var MappingMenus = _mapper.Map<List<MenusList_VE>>(GetMenus);
				return MappingMenus;
			}
			catch (Exception MenuEx)
			{

				throw MenuEx;
			}
		}

		public async Task<List<MenusRolesMap_VE>> GetAllMenusByRole(string UserRole)
		{
			try
			{
				var GetMenus = await _iEFRepository.FindAllByLambda<MenusRolesMap>(F => F.RoleName == UserRole);
				var MappingMenus = _mapper.Map<List<MenusRolesMap_VE>>(GetMenus);
				return MappingMenus;
			}
			catch (Exception MenuEx)
			{

				throw MenuEx;
			}
		}

		public async Task<Response_VE> AddRolesToMenus(List<MenusRolesMap_VE> menusRolesMap_VEs)
		{
			try
			{
				Response_VE NewResponse = new Response_VE();
				var MappingData = _mapper.Map<List<MenusRolesMap>>(menusRolesMap_VEs);
				if (MappingData!=null)
				{
					foreach (var item in MappingData)
					{
						item.RoleId = _iEFRepository.Single<AspNetRoles>(S => S.Name == item.RoleName).Id;
						
						if (item.RoleId!=null && (_iEFRepository.Single<MenusList>(F=>F.MenuId==item.MenuId).MenuName)!=null)
						{
							await _iEFRepository.CreateAsync<MenusRolesMap>(item);
						}
					}
					NewResponse.Message = "Roles Mapped To Menus Successful";
				}
				else
				{
					NewResponse.Message = "Roles Mapped To Menus Failed";
				}
				return NewResponse;
			}
			catch (Exception EX)
			{

				throw EX;
			}
		}

		public async Task<Response_VE> CreateNewMenus(List<MenusList_VE> menusList_VEs)
		{
			try
			{
				Response_VE NewResponse = new Response_VE();
				var MappingData = _mapper.Map<List<MenusList>>(menusList_VEs);
				if (MappingData != null)
				{
					foreach (var item in MappingData)
					{
						await _iEFRepository.CreateAsync<MenusList>(item);
					}
					NewResponse.Message = "Menus Creation Successful";
				}
				else
				{
					NewResponse.Message = "Menus Creation Failed";
				}
				return NewResponse;
			}
			catch (Exception Ex)
			{

				throw Ex;
			}
		}
	}
}
