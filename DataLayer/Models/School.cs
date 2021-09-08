using System.Collections.Generic;

namespace DataLayer.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<StudentDto> Students { get; set; } = new List<StudentDto>();
    }
}
