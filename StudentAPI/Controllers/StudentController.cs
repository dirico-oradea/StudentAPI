using DataLayer.Models;

using Microsoft.AspNetCore.Mvc;

using StudentAPI.Services;

using System.Collections.Generic;

namespace StudentAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService studentService = new StudentService();

        [HttpGet]
        [Route("all")]
        public ActionResult<List<StudentDto>> GetAllStudents([FromHeader] string password)
        {
            //if (password != "rightpassword")
            //{
            //    return Unauthorized();
            //}
            return studentService.GetAllStudents();
        }

        [HttpGet]
        [Route("id/{studentId}")]
        public ActionResult<StudentDto> GetStudentById([FromRoute] int studentId)
        {
            try
            {
                return Ok(studentService.GetStudentById(studentId));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("find")]
        public List<StudentDto> GetStudentsByProfile([FromQuery] string profile)
        {
            return studentService.GetStudentsByProfile(profile);
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<StudentDto> CreateStudent([FromBody] StudentDto student)
        {
            return Created("id/" + student.Id, studentService.CreateStudent(student));
        }

        [HttpDelete]
        [Route("delete/{studentId}")]
        public ActionResult DeleteStudentById([FromRoute] int studentId)
        {
            try
            {
                studentService.DeleteStudentById(studentId);

                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("update/{studentId}")]
        public ActionResult<StudentDto> UpdateStudentById([FromRoute] int studentId, [FromBody] StudentDto changedStudent)
        {
            try
            {
                return Ok(studentService.UpdateStudentById(studentId, changedStudent));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}