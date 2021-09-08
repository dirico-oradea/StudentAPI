
using System.Collections.Generic;

namespace StudentAPI.DTOs
{
    public class SchoolDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentDto> Students { get; set; } = new List<StudentDto>();
    }
}
