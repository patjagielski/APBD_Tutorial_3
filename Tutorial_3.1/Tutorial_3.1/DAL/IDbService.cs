using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial_3._1.DAL
{
    public interface IDbService
    {
        public IEnumerable<Models.Student> GetStudents(); 
    }
}
