namespace DataLayer.Models
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Profile { get; set; }

        public int? SchoolId { get; set; }
        public School School { get; set; }
    }
}
