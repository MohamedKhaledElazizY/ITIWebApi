using ITIWebApi.Context;
using ITIWebApi.IRepo;
using ITIWebApi.Models;

namespace ITIWebApi.Repo
{
    public class StudentRepo :Repo<Student>, IStudentRepo
    {
        private readonly DBContext _context;
        public StudentRepo(DBContext context): base(context)
        {
            _context = context;
        }
        public Student GetStudentByName(string name)
        {
            return _context.Students.FirstOrDefault(s => s.Name == name);
        }
    }
}
