using ApplicationLayer.Application_View_Entities.Project_Issues_View_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Application_Repositories.Dapper_Repositories
{
	public interface IDapper_Repository
	{
		Task<IEnumerable<Project_Issues_VE>> GetAllProjectIssues(int? ProjectId, int? IssueId, int? StatusId);
	}
}
