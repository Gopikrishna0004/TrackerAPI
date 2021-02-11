using ApplicationLayer.Application_View_Entities.Project_View_Entities;
using AutoMapper;
using DomainLayer.Table_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Application_Profiles.Project_Management
{
	public class Project_Profile : Profile
	{
		public Project_Profile()
		{
			CreateMap<Project_VE, TblProjects>();

			CreateMap<TblProjects, Project_VE>();
		}
	}
}
