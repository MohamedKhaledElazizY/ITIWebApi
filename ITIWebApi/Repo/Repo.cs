using ITIWebApi.Context;
using ITIWebApi.IRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ITIWebApi.Repo
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private readonly DBContext _context;
        public Repo(DBContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
        }
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.ToList();
        }
        public T GetById(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.FirstOrDefault(x=> EF.Property<int>(x, "Id") == id);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
