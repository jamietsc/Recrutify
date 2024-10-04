
namespace Recrutify.DataAccessLayer.Repositories
{
    public interface IAdmin<T> where T : class
    {
        Task<int> CheckCredentials(T model);
    }
}
