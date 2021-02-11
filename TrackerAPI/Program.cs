using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;

namespace TrackerAPI
{
	public class Program
	{
		public static IConfiguration configuration { get; } = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
			.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
			.Build();
		public static void Main(string[] args)
		{
			string connectionstring = configuration.GetConnectionString("Tracker_ConnStr");

			var columnOptions = new ColumnOptions
			{
				AdditionalColumns = new Collection<SqlColumn>
				{
					new SqlColumn("UserName",SqlDbType.VarChar)
				}
			};

			Log.Logger=new LoggerConfiguration()
				.Enrich.FromLogContext()
				.WriteTo.MSSqlServer(connectionstring,
				sinkOptions: new SinkOptions { TableName = "TBL_WebApiLogs"}
				, null,null,LogEventLevel.Information,null,columnOptions: columnOptions,null,null)
				.MinimumLevel.Override("Microsoft",LogEventLevel.Error)
				.CreateLogger();
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				}).UseSerilog();
	}
}
