using Recrutify.DataAccessLayer.Repository;
using Recrutify.DataAccessLayer.SqlDataAccess;
using Recrutify.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recrutify.DataAccessLayer.Data
{
    public class BewerberData : IBewerber<BewerberModel>
    {
        private readonly ISqlDataAccess _db;
        public BewerberData(ISqlDataAccess db) {
            _db = db;
        }

    public async Task<int> InsertVornameNachname(BewerberModel model)
    {
            var parameters = new { model.Vorname, model.Nachname };
            int insertedID = await _db.SaveDataReturnID("sp", parameters);
            model.BID = insertedID;
            return insertedID;
    }
}
