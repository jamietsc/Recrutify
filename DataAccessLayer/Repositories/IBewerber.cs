using Recrutify.Models;

namespace Recrutify.DataAccessLayer.Repository
{
    public interface IBewerber<T> where T : class
    {
        Task<int> InsertVornameNachname(T model);
            
    }
}
