using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tutorial_3._1.DAL;

namespace Tutorial_3._1.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IDbService _dbService;
        public StudentController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudent(string orderBy)
        {

            return Ok(_dbService.GetStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            }
            else if (id == 2)
            {
                return Ok("Malewski");
            }
            return NotFound("Nothing found");

        }

        [HttpPost]
        public IActionResult CreateStudent(Models.Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
           
            return Ok(student);

        }
        [HttpPut]
        public IActionResult PutStudent([FromBody] Models.Student student)
        {
            student.FirstName = "Mark";

            return Ok("Update complete");

        }
        [HttpDelete]
        public IActionResult DeleteStudent([FromBody] Models.Student student)
        {
            if(student.IdStudent == 1)
            {
                return Ok("Delete complete");
            }
            else
            {
                return NotFound("That student id does not exist");
            }
        }
    }
   
}
