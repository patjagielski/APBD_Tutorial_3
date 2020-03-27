using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public IActionResult GetStudent(string id)
        {
            string studies = "";
            using (var sqlConnection = new SqlConnection(@"Data Source=db-mssql;Initial Catalog=s19696;Integrated Security=True"))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = sqlConnection;
                    string query = "select x.IndexNumber,y.semester,w.Name" +
                                " from Student a join Enrollment b" +
                                " on x.IdEnrollment = y.IdEnrollment join Studies W" +
                                $" on W.idStudy = y.IdStudy where x.IndexNumber ='{id}';";
                    command.CommandText = (query);
                    sqlConnection.Open();
                    var dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        studies = studies + $"Student:{dr["IndexNumber"]} Semester:{dr["Semester"].ToString()} Studies:{dr["Name"]} \n";
                    }
                }
                return Ok();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            string studies = "";
            using (var client = new SqlConnection(@"Data Source=db-mssql;Initial Catalog=s19696;Integrated Security=True"))
            {
                using (var con = new SqlCommand())
                {
                    con.Connection = client;
                    string query = "select a.IndexNumber,b.semester,c.Name" +
                                " from Student a join Enrollment b" +
                                " on a.IdEnrollment = b.IdEnrollment join Studies C" +
                                $" on C.idStudy = b.IdStudy where a.IndexNumber ='{id}';";

                    con.CommandText = (query);
                    client.Open();
                    var dr = con.ExecuteReader();
                    while (dr.Read())
                    {
                        studies = studies + $"Student:{dr["IndexNumber"]} Semester:{dr["Semester"].ToString()} Studies:{dr["Name"]} \n";
                    }

                }

            }
            return Ok(studies);

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
