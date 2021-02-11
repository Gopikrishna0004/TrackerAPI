using ApplicationLayer.Application_Repositories.EF_Repositories;
using ApplicationLayer.Application_View_Entities.Project_View_Entities;
using AutoMapper;
using DomainLayer.Table_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Application_Services.Project_Management
{
	public class Project_Service : IProject_Service
	{
		private readonly IEFRepository _iEFRepository;

		private readonly IMapper _mapper;
		public Project_Service(IEFRepository iEFRepository, IMapper mapper)
		{
			_iEFRepository = iEFRepository;
			_mapper = mapper;
		}

		public async Task<bool> AddNewProject(Project_VE project_VEs)
		{
			try
			{
				var Result = false;
				if ((_iEFRepository.Single<TblProjects>(F=>F.ProjectName == project_VEs.ProjectName))==null)
				{
					var Map_Object = _mapper.Map<TblProjects>(project_VEs);
					await _iEFRepository.CreateAsync<TblProjects>(Map_Object);
					Result = true;
				}
				return Result;
			}
			catch (Exception Ex)
			{
				throw Ex;
			}
		}

		public async Task<List<Project_VE>> GetAllProjects()
		{
			try
			{
				var getProjects = await _iEFRepository.FindAll<TblProjects>();
				var Map_Object = _mapper.Map<List<Project_VE>>(getProjects);
				return Map_Object;
			}
			catch (Exception Ex)
			{

				throw Ex;
			}
		}
		public async Task<bool> UpdateProjectDetails(Project_VE project_VEs)
		{
			try
			{
				var Result = false;
				var TblData = _iEFRepository.Single<TblProjects>(F => F.ProjectId == project_VEs.ProjectId);
				if (TblData != null)
				{
					_mapper.Map<Project_VE,TblProjects>(project_VEs, TblData);
					await _iEFRepository.UpdateAsync<TblProjects>(TblData);
					Result = true;
				}
				return Result;
			}
			catch (Exception Ex)
			{
				throw Ex;
			}
		}
	}
}
