using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Department.Microservice.Bases;
using Department.Microservice.Models;
using Department.Microservice.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Department.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class DepartmentsController : BaseController<Departments, DepartmentRepository>
    {
        public DepartmentsController(DepartmentRepository department) : base(department)
        {

        }
    }
}
