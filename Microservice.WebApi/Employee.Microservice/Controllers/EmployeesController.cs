using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Microservice.Bases;
using Employee.Microservice.Models;
using Employee.Microservice.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employees, EmployeeRepository>
    {
        public EmployeesController(EmployeeRepository employee) : base(employee)
        {

        }
    }
}
