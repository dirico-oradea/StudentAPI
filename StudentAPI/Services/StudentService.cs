using DataLayer;
using DataLayer.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAPI.Services
{
    public class StudentService
    {
        public List<StudentDto> GetAllStudents()
        {
            using var db = new SqlContext();
            var result = db.Students
                .Where(x => x.Id > 0)
                .ToList();

            return result;
        }

        public StudentDto GetStudentById(int studentId)
        {
            using var db = new SqlContext();
            var result = db.Students
                .FirstOrDefault(x => x.Id == studentId);

            return result;
        }

        public List<StudentDto> GetStudentsByProfile(string profile)
        {
            using var db = new SqlContext();
            var result = db.Students
                .Where(x => x.Profile != null && x.Profile.ToLower() == profile.ToLower())
                .ToList();

            return result;
        }

        public StudentDto CreateStudent(StudentDto student)
        {
            using var db = new SqlContext();
            db.Students.Add(student);
            db.SaveChanges();

            return student;
        }

        public void DeleteStudentById(int studentId)
        {
            using var db = new SqlContext();
            var student = db.Students
                    .FirstOrDefault(x => x.Id == studentId);

            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }
            else
            {
                throw new Exception("The student with the specified ID was not found.");
            }
        }

        public StudentDto UpdateStudentById(int studentId, StudentDto changedStudent)
        {
            using var db = new SqlContext();
            var student = db.Students
                    .FirstOrDefault(x => x.Id == studentId);

            if (student != null)
            {
                student.Name = changedStudent.Name;
                student.Profile = changedStudent.Profile;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("The student with the specified ID was not found.");
            }

            return student;
        }
    }
}
