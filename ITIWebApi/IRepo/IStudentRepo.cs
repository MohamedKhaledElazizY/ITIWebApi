using ITIWebApi.Models;

namespace ITIWebApi.IRepo
{
    public interface IStudentRepo:IRepo<Student>
    {
            Student GetStudentByName(string name);
        
    }
}
