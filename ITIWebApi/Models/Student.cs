namespace ITIWebApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateOnly BirthDate { get; set; }
        public int Deptid {  get; set; }
        public Departmment? Dept { get; set; }
    }
}
