/* using Dapper;
using System.Data;
using System.Data.SqlClient;
using Recrutify.DataAccessLayer.SqlDataAccess;

namespace Recrutify.DataAccessLayer.SqlDataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public string ConnectionStringName { get; set; }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionID = "DefaultConnection")
        {
            using IDbConnection connection = new SqlConnection(_config.GetSection("ConnectionStrings")[connectionID]);
            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string storedProcedure, T parameters, string connectionID = "DefaultConnection")
        {
            using IDbConnection connection = new SqlConnection(_config.GetSection("ConnectionStrings")[connectionID]);
            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> SaveDataReturnID<T>(string storedProcedure, T parameters, string connectionID = "DefaultConnection")
        {
            using IDbConnection connection = new SqlConnection(_config.GetSection("ConnectionStrings")[connectionID]);
            return await connection.ExecuteScalarAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
*/