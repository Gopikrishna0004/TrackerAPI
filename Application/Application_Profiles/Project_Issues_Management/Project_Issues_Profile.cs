using ApplicationLayer.Application_View_Entities.Project_Issues_View_Entities;
using AutoMapper;
using DomainLayer.Table_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Application_Profiles.Project_Issues_Management
{
	public class Project_Issues_Profile : Profile
	{
		public Project_Issues_Profile()
		{
			CreateMap<Project_Issues_VE, TblProjectIssues>();

			CreateMap<TblProjectIssues, Project_Issues_VE>();
		}
	}
}
