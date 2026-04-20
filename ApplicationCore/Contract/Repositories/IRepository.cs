using ApplicationCore.Entities;

namespace ApplicationCore.Contract.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<int> Insert(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int id);
    }
}
