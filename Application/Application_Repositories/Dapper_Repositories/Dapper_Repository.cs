using ApplicationLayer.Application_View_Entities.Project_Issues_View_Entities;
using Dapper;
using DomainLayer.Table_Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Application_Repositories.Dapper_Repositories
{
	public class Dapper_Repository : IDapper_Repository
	{
		private readonly IConfiguration _configuration;

		public Dapper_Repository(IConfiguration configuration)
		{
			_configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
		}

		public SqlConnection Connection
		{
			get
			{
				return new SqlConnection(_configuration.GetConnectionString("Tracker_ConnStr"));
			}
		}

		public async Task<IEnumerable<Project_Issues_VE>> GetAllProjectIssues(int? ProjectId, int? IssueId, int? StatusId)
		{
			using (Connection)
			{
				try
				{
					var result = await Connection.QueryAsync<Project_Issues_VE>("EXEC [SP_Get_All_Projects_Issues] " + ProjectId + "," + IssueId + ",'" + StatusId + "'").ConfigureAwait(false);
					return result;
				}
				catch (Exception Ex)
				{

					throw Ex;
				}
			}
		}
	}
}
