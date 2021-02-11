using ApplicationLayer.Application_Repositories.EF_Repositories;
using ApplicationLayer.Application_View_Entities.Master_View_Entities;
using AutoMapper;
using DomainLayer.Table_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Application_Services.Master_Management
{
	public class Master_Service : IMaster_Service
	{
		private readonly IEFRepository _iEFRepository;
		private readonly IMapper _mapper;

		public Master_Service(IEFRepository iEFRepository,IMapper mapper)
		{
			_iEFRepository = iEFRepository;
			_mapper = mapper;
		}

		public async Task<bool> AddIssuPriorities(MasterIssuesPriorities masterIssuesPriorities)
		{
			try
			{
				var Result = false;
				var Map_Object = _mapper.Map<TblMasterIssuePriorities>(masterIssuesPriorities);
				await _iEFRepository.CreateAsync<TblMasterIssuePriorities>(Map_Object);
				Result = true;
				return Result;
			}
			catch (Exception Ex)
			{
				throw Ex;
			}
		}

		public async Task<List<MasterIssuesPriorities>> GetIssuPriorities()
		{
			try
			{
				var getIssues =await _iEFRepository.FindAll<TblMasterIssuePriorities>();
				var Map_Object= _mapper.Map<List<MasterIssuesPriorities>>(getIssues);
				return Map_Object;
			}
			catch (Exception GetIssues)
			{
				throw GetIssues;
			}
		}

		public async Task<bool> AddIssueStatus(MasterIssueStatuses masterIssueStatuses)
		{
			try
			{
				var Result = false;
				var Map_Object = _mapper.Map<TblMasterIssueStatuses>(masterIssueStatuses);
				await _iEFRepository.CreateAsync<TblMasterIssueStatuses>(Map_Object);
				Result = true;
				return Result;
			}
			catch (Exception Ex)
			{
				throw Ex;
			}
		}
		public async Task<List<MasterIssueStatuses>> GetIssueStatuses()
		{
			try
			{
				var getIssuestatus = await _iEFRepository.FindAll<TblMasterIssueStatuses>();
				var Map_Object = _mapper.Map<List<MasterIssueStatuses>>(getIssuestatus);
				return Map_Object;
			}
			catch (Exception getstatus)
			{
				throw getstatus;
			}
		}
	}
}
