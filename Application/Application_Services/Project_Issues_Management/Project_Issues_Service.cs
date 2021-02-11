using ApplicationLayer.Application_Repositories.Dapper_Repositories;
using ApplicationLayer.Application_Repositories.EF_Repositories;
using ApplicationLayer.Application_View_Entities.Project_Issues_View_Entities;
using AutoMapper;
using DomainLayer.Table_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Application_Services.Project_Issues_Management
{
	public class Project_Issues_Service : IProject_Issues_Service
	{
		private readonly IEFRepository _iEFRepository;

		private readonly IMapper _mapper;
		private readonly IDapper_Repository _dapper_Repository;

		public Project_Issues_Service(IEFRepository iEFRepository, IMapper mapper, IDapper_Repository dapper_Repository)
		{
			_iEFRepository = iEFRepository;
			_mapper = mapper;
			_dapper_Repository = dapper_Repository;
		}
		public async Task<bool> AddProjectIssues(Project_Issues_VE project_Issues_VEs)
		{
			try
			{
				var Result = false;
				var Map_Object = _mapper.Map<TblProjectIssues>(project_Issues_VEs);
				await _iEFRepository.CreateAsync<TblProjectIssues>(Map_Object);
				Result = true;
				return Result;
			}
			catch (Exception Ex)
			{
				throw Ex;
			}
		}

		public async Task<List<Project_Issues_VE>> GetAllProjectIssues(int? ProjectId, int? IssueId,int? StatusId)
		{
			var Result = await _dapper_Repository.GetAllProjectIssues(ProjectId, IssueId, StatusId);
			var FinalResult = _mapper.Map<List<Project_Issues_VE>>(Result);
			return FinalResult;
		}
	}
}
