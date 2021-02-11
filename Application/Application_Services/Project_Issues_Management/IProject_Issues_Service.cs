using ApplicationLayer.Application_View_Entities.Project_Issues_View_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Application_Services.Project_Issues_Management
{
	public interface IProject_Issues_Service
	{
		Task<bool> AddProjectIssues(Project_Issues_VE project_Issues_VEs);
		Task<List<Project_Issues_VE>> GetAllProjectIssues(int? ProjectId, int? IssueId, int? StatusId);
	}
}
