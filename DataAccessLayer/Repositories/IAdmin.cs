namespace Recrutify.DataAccessLayer.Repositories
{
    public interface IAdmin<T> where T : class
    {
        Task<bool> CheckCredentials(T model);
    }
}
