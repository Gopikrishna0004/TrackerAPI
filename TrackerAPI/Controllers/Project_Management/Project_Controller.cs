using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLayer.Application_Services.Project_Management;
using ApplicationLayer.Application_View_Entities.Project_View_Entities;
using ApplicationLayer.Application_View_Entities.Response_View_Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrackerAPI.Controllers.Project_Management
{
	[Route("api/[controller]")]
	[ApiController]
	public class Project_Controller : ControllerBase
	{
		private readonly IProject_Service _project_Service;

		public Project_Controller(IProject_Service project_Service)
		{
			_project_Service = project_Service;
		}

		[HttpPost("AddNewProject")]
		public async Task<IActionResult> AddNewProject(Project_VE project_VEs)
		{
			Response_VE response_VE = new Response_VE();
			if (project_VEs != null)
			{
				var Add_NewProject = await _project_Service.AddNewProject(project_VEs);
				if (Add_NewProject == true)
				{
					response_VE.Status = "201"; response_VE.Message = "New Project Added Successfully...!";
				}
				else
				{
					response_VE.Status = "204"; response_VE.Message = "New Project Added failed due to Project Name already existed or other reasons,Please check the data...!";
				}
			}
			else
			{
				response_VE.Status = "404"; response_VE.Message = "No Objects found to Add...!";
			}
			return Ok(response_VE);
		}

		[HttpGet("GetAllProjects")]
		public async Task<IActionResult> GetAllProjects()
		{
			var GetProjects = await _project_Service.GetAllProjects();
			return Ok(GetProjects);
		}

		[HttpPut("UpdateProjectDetails")]
		public async Task<IActionResult> UpdateProjectDetails(Project_VE project_VEs)
		{
			Response_VE response_VE = new Response_VE();
			if (project_VEs != null)
			{
				var Update_Project = await _project_Service.UpdateProjectDetails(project_VEs);
				if (Update_Project == true)
				{
					response_VE.Status = "201"; response_VE.Message = "Project Updated Successfully...!";
				}
				else
				{
					response_VE.Status = "204"; response_VE.Message = "Project Details Updated Failed...!";
				}
			}
			else
			{
				response_VE.Status = "404"; response_VE.Message = "No Objects found to Update Project Details...!";
			}
			return Ok(response_VE);
		}
	}
}
