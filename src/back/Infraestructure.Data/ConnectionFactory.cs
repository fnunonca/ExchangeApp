using Microsoft.Extensions.Configuration;
using System.Data;
using Transversal.Common;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection
                {
                    ConnectionString = _configuration.GetConnectionString("ConnectionString")
                };
                sqlConnection.Open();
                return sqlConnection;
            }
        }
    }
}
