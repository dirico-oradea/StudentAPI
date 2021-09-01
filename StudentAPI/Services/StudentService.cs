using StudentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Services
{
    public class StudentService
    {
        private static List<Student> MyStudents = new List<Student>()
        {
            new Student() { Id = 1, Name = "John Doe", Profile = "IT" },
            new Student() { Id = 2, Name = "Jane Doe", Profile = "IT" },
            new Student() { Id = 3, Name = "John Smith", Profile = "Physics" },
        };

        public List<Student> GetAllStudents()
        {
            return MyStudents;
        }

        public Student GetStudentById(int studentId)
        {
            return MyStudents.First(s => s.Id == studentId);
        }

        public List<Student> GetStudentsByProfile(string profile)
        {
            return MyStudents.Where(s => s.Profile == profile).ToList();
        }

        public Student CreateStudent(Student student)
        {
            MyStudents.Add(student);
            return student;
        }

        public void DeleteStudentById(int studentId)
        {
            if (MyStudents.Any(s => s.Id == studentId))
            {
                MyStudents = MyStudents.Where(s => s.Id != studentId).ToList();
            }
            else
            {
                throw new Exception("The student with the specified ID was not found.");
            }
        }

        public Student UpdateStudentById(int studentId, Student changedStudent)
        {
            Student studentToUpdate = MyStudents.First(s => s.Id == studentId);

            studentToUpdate.Name = changedStudent.Name;
            studentToUpdate.Profile = changedStudent.Profile;

            return studentToUpdate;
        }
    }
}
