using Dapper;
using System.Data;
using Recrutify.DataAccessLayer.SqlDataAccess;
using System.Data.SQLite;
using Microsoft.Data.Sqlite;

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
            using IDbConnection connection = new SqliteConnection(_config.GetSection("ConnectionStrings")[connectionID]);
            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.Text); // SQLite nutzt in der Regel SQL Queries statt Stored Procedures
        }

        public async Task SaveData<T>(string storedProcedure, T parameters, string connectionID = "DefaultConnection")
        {
            using IDbConnection connection = new SqliteConnection(_config.GetSection("ConnectionStrings")[connectionID]);
            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.Text);
        }

        public async Task<int> SaveDataReturnID<T>(string storedProcedure, T parameters, string connectionID = "DefaultConnection")
        {
            using IDbConnection connection = new SqliteConnection(_config.GetSection("ConnectionStrings")[connectionID]);
            return await connection.ExecuteScalarAsync<int>(storedProcedure, parameters, commandType: CommandType.Text);
        }
    }
}