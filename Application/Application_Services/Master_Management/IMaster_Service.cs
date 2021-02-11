using ApplicationLayer.Application_View_Entities.Master_View_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Application_Services.Master_Management
{
	public interface IMaster_Service
	{
		Task<bool> AddIssuPriorities(MasterIssuesPriorities issuesPriorities);
		Task<List<MasterIssuesPriorities>> GetIssuPriorities();
		Task<bool> AddIssueStatus(MasterIssueStatuses masterIssueStatuses);
		Task<List<MasterIssueStatuses>> GetIssueStatuses();
	}
}
