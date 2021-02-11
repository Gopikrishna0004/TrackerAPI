using ApplicationLayer.Application_Profiles.Master_Management;
using ApplicationLayer.Application_Profiles.Menu_Management;
using ApplicationLayer.Application_Profiles.Project_Issues_Management;
using ApplicationLayer.Application_Profiles.Project_Management;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Application_Profiles.Main_Mappings
{
    public static class Mapping_Profiles
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Menu_Profiles());
                cfg.AddProfile(new Project_Issues_Profile());
                cfg.AddProfile(new Project_Profile());
                cfg.AddProfile(new Masters_Profile());
            });
            return config;
        }
    }
}
