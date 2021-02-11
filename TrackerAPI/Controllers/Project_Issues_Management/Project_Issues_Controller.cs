using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLayer.Application_Services.Project_Issues_Management;
using ApplicationLayer.Application_View_Entities.Project_Issues_View_Entities;
using ApplicationLayer.Application_View_Entities.Response_View_Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrackerAPI.Controllers.Project_Issues_Management
{
	[Route("api/[controller]")]
	[ApiController]
	public class Project_Issues_Controller : ControllerBase
	{
		private readonly IProject_Issues_Service _projectIssuesService;

		public Project_Issues_Controller(IProject_Issues_Service projectIssuesService)
		{
			_projectIssuesService = projectIssuesService;
		}

		[HttpPost("AddProjectIssues")]
		public async Task<IActionResult> AddProjectIssues(Project_Issues_VE project_Issues_VEs)
		{
			Response_VE response_VE = new Response_VE();
			if (project_Issues_VEs != null)
			{
				var Add_NewProject = await _projectIssuesService.AddProjectIssues(project_Issues_VEs);
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

		[HttpGet("GetAllProjectIssues/{ProjectId}/{IssueId}/{StatusId}")]
		public async Task<IActionResult> GetAllProjectIssues(int? ProjectId,int? IssueId, int? StatusId)
		{
			var GetIssues = await _projectIssuesService.GetAllProjectIssues(ProjectId, IssueId, StatusId);
			return Ok(GetIssues);
		}
	}
}
