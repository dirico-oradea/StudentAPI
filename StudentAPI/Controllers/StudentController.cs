using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Services;

namespace StudentAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentService studentService = new StudentService();

        [HttpGet]
        [Route("all")]
        public ActionResult<List<Student>> GetAllStudents([FromHeader]string password)
        {
            if (password != "rightpassword")
            {
                return Unauthorized();
            }
            return this.studentService.GetAllStudents();
        }

        [HttpGet]
        [Route("id/{studentId}")]
        public ActionResult<Student> GetStudentById([FromRoute]int studentId)
        {
            try
            {
                return Ok(this.studentService.GetStudentById(studentId));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("find")]
        public List<Student> GetStudentsByProfile([FromQuery]string profile)
        {
            return this.studentService.GetStudentsByProfile(profile);
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<Student> CreateStudent([FromBody]Student student)
        {
            return Created("id/" + student.Id, this.studentService.CreateStudent(student));
        }

        [HttpDelete]
        [Route("delete/{studentId}")]
        public ActionResult DeleteStudentById([FromRoute]int studentId)
        {
            try
            {
                this.studentService.DeleteStudentById(studentId);

                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("update/{studentId}")]
        public ActionResult<Student> UpdateStudentById([FromRoute]int studentId, [FromBody]Student changedStudent)
        {
            try
            {
                return Ok(this.studentService.UpdateStudentById(studentId, changedStudent));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}