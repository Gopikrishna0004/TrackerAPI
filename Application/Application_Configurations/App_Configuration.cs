using ApplicationLayer.Application_Profiles.Main_Mappings;
using ApplicationLayer.Application_Repositories.Dapper_Repositories;
using ApplicationLayer.Application_Repositories.EF_Repositories;
using ApplicationLayer.Application_Services.Master_Management;
using ApplicationLayer.Application_Services.Menu_Management;
using ApplicationLayer.Application_Services.Project_Issues_Management;
using ApplicationLayer.Application_Services.Project_Management;
using AutoMapper;
using DomainLayer.Table_Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Application_Configurations
{
    public static class ServicesConfiguration
    {
        public static void AddCoreServices(this IServiceCollection serviceCollection)
        {
            IConfiguration configuration;
            using (var serviceProvider = serviceCollection.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            //Data Connection
            serviceCollection.AddDbContext<Tracker_Db_Context>(options => options.UseSqlServer(configuration.GetConnectionString("Tracker_ConnStr")));

            //Data Layer
            serviceCollection.AddScoped<IEFRepository, EFRepository<Tracker_Db_Context>>();

            // Register dapper in scope
            serviceCollection.AddScoped<IDapper_Repository, Dapper_Repository>();

            //Service Layer
            serviceCollection.AddScoped<IMenu_Service, Menu_Service>();
            serviceCollection.AddScoped<IMaster_Service, Master_Service>();
            serviceCollection.AddScoped<IProject_Service, Project_Service>();
            serviceCollection.AddScoped<IProject_Issues_Service, Project_Issues_Service>();

            //mapping profile
            serviceCollection.AddAutoMapper(typeof(ServicesConfiguration));
            var autoMapperConfig = Mapping_Profiles.InitializeAutoMapper();
            IMapper mapper = autoMapperConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }
    }
}
