using AutoMapper;
using ITIWebApi.DTO;
using ITIWebApi.Models;

namespace ITIWebApi.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<Departmment, DepartmentDto>().ForMember(c=>c.studentsName,op=>op.MapFrom(x=>x.Students.Select(t=>t.Name)));
            CreateMap<DepartmentDto, Departmment>();
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();

        }
    }
}
