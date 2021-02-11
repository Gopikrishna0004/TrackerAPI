using ApplicationLayer.Application_View_Entities.Project_View_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Application_Services.Project_Management
{
	public interface IProject_Service
	{
		Task<bool> AddNewProject(Project_VE project_VEs);
		Task<List<Project_VE>> GetAllProjects();
		Task<bool> UpdateProjectDetails(Project_VE project_VEs);
	}
}
