using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLayer.Application_Services.Master_Management;
using ApplicationLayer.Application_View_Entities.Master_View_Entities;
using ApplicationLayer.Application_View_Entities.Response_View_Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrackerAPI.Controllers.Masters_Management
{
	[Route("api/[controller]")]
	[ApiController]
	public class Masters_Controller : ControllerBase
	{
		private readonly IMaster_Service _master_Service;

		public Masters_Controller(IMaster_Service master_Service)
		{
			_master_Service = master_Service;
		}

		[HttpPost("AddIssuPriorities")]
		public async Task<IActionResult> AddIssuPriorities(MasterIssuesPriorities masterIssuesPriorities)
		{
			Response_VE response_VE = new Response_VE();
			if (masterIssuesPriorities != null)
			{
				var Add_Prioriries =await _master_Service.AddIssuPriorities(masterIssuesPriorities);
				if (Add_Prioriries==true)
				{
					response_VE.Status = "201"; response_VE.Message = "Issue Priority Added Successfully...!";
				}
				else
				{
					response_VE.Status = "204"; response_VE.Message = "Issue Priority Added failed...!";
				}
			}
			else
			{
				response_VE.Status = "404"; response_VE.Message = "No Objects found to Add...!";
			}
			return Ok(response_VE);
		}

		[HttpGet("GetIssuPriorities")]
		public async Task<IActionResult> GetIssuPriorities()
		{
			var GetIssues = await _master_Service.GetIssuPriorities();
			return Ok(GetIssues);
		}

		[HttpPost("AddIssueStatus")]
		public async Task<IActionResult> AddIssueStatus(MasterIssueStatuses masterIssueStatuses)
		{
			Response_VE response_VE = new Response_VE();
			if (masterIssueStatuses != null)
			{
				var Add_Issue_Status = await _master_Service.AddIssueStatus(masterIssueStatuses);
				if (Add_Issue_Status == true)
				{
					response_VE.Status = "201"; response_VE.Message = "Issue Status Added Successfully...!";
				}
				else
				{
					response_VE.Status = "204"; response_VE.Message = "Issue Status Added failed...!";
				}
			}
			else
			{
				response_VE.Status = "404"; response_VE.Message = "No Objects found to Add...!";
			}
			return Ok(response_VE);
		}

		[HttpGet("GetIssueStatuses")]
		public async Task<IActionResult> GetIssueStatuses()
		{
			var GetIssues = await _master_Service.GetIssueStatuses();
			return Ok(GetIssues);
		}
	}
}
