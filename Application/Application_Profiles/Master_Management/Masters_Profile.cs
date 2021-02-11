using ApplicationLayer.Application_View_Entities.Master_View_Entities;
using AutoMapper;
using DomainLayer.Table_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Application_Profiles.Master_Management
{
	public class Masters_Profile : Profile
	{
		public Masters_Profile()
		{
			CreateMap<MasterIssuesPriorities, TblMasterIssuePriorities>();

			CreateMap<TblMasterIssuePriorities, MasterIssuesPriorities>();

			CreateMap<MasterIssueStatuses, TblMasterIssueStatuses>();

			CreateMap<TblMasterIssueStatuses, MasterIssueStatuses>();
		}
	}
}
