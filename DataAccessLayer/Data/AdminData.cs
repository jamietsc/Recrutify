using Recrutify.DataAccessLayer.SqlDataAccess;
using Recrutify.DataAccessLayer.Repositories;
using Recrutify.Models;
using System.Numerics;

namespace Recrutify.DataAccessLayer.Data
{
    public class AdminData
    {
        private readonly ISqlDataAccess _db;
        public AdminData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<int> CheckCredentials(AdminModel model)
        {
            var parameters = new { model.Benutzername, model.Passwort };
            string sqlQuery = "SELECT Benutzername = @Benutzername, Passwort = @Passwort FROM Unternehmen;";
            return await _db.LoadData(sqlQuery, parameters);
        }
    }
}
