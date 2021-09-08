
using Microsoft.AspNetCore.Mvc;

using StudentAPI.DTOs;
using StudentAPI.Services;

using System.Collections.Generic;

namespace StudentAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly SchoolService _schoolService = new SchoolService();

        [HttpGet]
        [Route("all")]
        public ActionResult<List<SchoolDto>> GetAllSchools()
        {
            return _schoolService.GetAllSchools();
        }
    }
}
