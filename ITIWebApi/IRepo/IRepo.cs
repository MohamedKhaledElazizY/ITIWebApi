using System.Linq.Expressions;

namespace ITIWebApi.IRepo
{
    public interface IRepo<T> where T : class
    {
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        T GetById(int id, params Expression<Func<T, object>>[] includeProperties);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
