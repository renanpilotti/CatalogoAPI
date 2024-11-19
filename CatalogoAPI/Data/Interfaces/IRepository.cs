using System.Linq.Expressions;

namespace CatalogoAPI.Data.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> Get(Expression<Func<T, bool>> predicate);
        T Create(T entity);
        T Update(T entity);
        Task<T> Delete(T entity);
    }
}
