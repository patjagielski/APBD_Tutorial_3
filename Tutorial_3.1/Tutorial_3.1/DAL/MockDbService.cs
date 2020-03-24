using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial_3._1.Models;

namespace Tutorial_3._1.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;
        
        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student{IdStudent = 1, FirstName="Pat", LastName ="Jagielski"},
                new Student{IdStudent = 2, FirstName="Alex", LastName ="Martynek"},
                new Student{IdStudent = 3, FirstName="Bob", LastName ="Marley"}
            };
        }
        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}
