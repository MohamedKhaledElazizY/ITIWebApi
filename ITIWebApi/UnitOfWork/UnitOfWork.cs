using ITIWebApi.Context;
using ITIWebApi.IRepo;
using ITIWebApi.Repo;

namespace ITIWebApi.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;
        public UnitOfWork(DBContext context)
        {
            _context = context;
        }
        public IRepo<T> Repos<T>() where T : class
        {
            return new Repo<T>(_context);
        }
        public IStudentRepo Students => new StudentRepo(_context);
        public  int SaveAsync()
        {
            return  _context.SaveChanges();
        }
    }
}
