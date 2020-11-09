using Employee.Microservice.Context;
using Employee.Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Microservice.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employees, MyContext>
    {
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
