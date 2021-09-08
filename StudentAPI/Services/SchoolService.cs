using DataLayer;

using Microsoft.EntityFrameworkCore;

using StudentAPI.DTOs;

using System.Collections.Generic;
using System.Linq;

namespace StudentAPI.Services
{
    public class SchoolService
    {
        public List<SchoolDto> GetAllSchools()
        {
            using var db = new SqlContext();
            var schools = db.Schools
                // if you remove .Include(), then students will not be fetched together with schools
                .Include(x => x.Students)
                .ToList();

            var result = new List<SchoolDto>();
            foreach (var school in schools)
            {
                // mapping school -> schoolDto
                var schoolDto = new SchoolDto
                {
                    Id = school.Id,
                    Name = school.Name,
                    // mapping student(s) => student(s)Dto
                    Students = school.Students.Select(y => new StudentDto()
                    {
                        Id = y.Id,
                        Name = y.Name,
                        Profile = y.Profile,
                        SchoolId = y.SchoolId
                    }).ToList()
                };

                result.Add(schoolDto);
            }
            return result;

            //// shorter version of the above code
            //return result.Select(x => new SchoolDto()
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Students = x.Students.Select(y => new StudentDto()
            //    {
            //        Id = y.Id,
            //        Name = y.Name,
            //        Profile = y.Profile,
            //        SchoolId = y.SchoolId
            //    }).ToList()
            //}).ToList();
        }
    }
}
