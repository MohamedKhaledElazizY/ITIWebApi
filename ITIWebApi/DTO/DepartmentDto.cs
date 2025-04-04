using ITIWebApi.CustomValidate;

namespace ITIWebApi.DTO
{
    public class DepartmentDto
    {
        [Unique]
        public string Name { get; set; }
        public string Location { get; set; }
        public int countofstds { get => studentsName?.Count??0; }
        public string message { get => countofstds > 3 ? "negative" : "Positve"; }
        public List<string> studentsName { get; set; }
        public DepartmentDto()
        {
            studentsName = new List<string>();
        }
    }
}
