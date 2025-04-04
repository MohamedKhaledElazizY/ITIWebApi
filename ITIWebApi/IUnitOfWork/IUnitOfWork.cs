using ITIWebApi.Context;
using ITIWebApi.IRepo;

namespace ITIWebApi.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepo<T> Repos<T>() where T : class;
        public IStudentRepo Students { get; }
        public int SaveAsync();
    }
}
