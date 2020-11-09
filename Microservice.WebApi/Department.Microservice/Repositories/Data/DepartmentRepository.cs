using Department.Microservice.Context;
using Department.Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Department.Microservice.Repositories.Data
{
  
    public class DepartmentRepository : GeneralRepository<Departments, MyContext>
    {
        public DepartmentRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
