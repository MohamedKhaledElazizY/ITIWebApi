using System.Text.Json.Serialization;

namespace ITIWebApi.Models
{
    public class Departmment
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [JsonIgnore]
        public List<Student> Students { get; set; }
    }
}
