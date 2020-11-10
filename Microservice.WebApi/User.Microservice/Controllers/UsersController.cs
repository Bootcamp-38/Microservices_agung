using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using User.Microservice.Bases;
using User.Microservice.Models;
using User.Microservice.Repositories.Data;

namespace User.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController<Users, UserRepository>
    {
        public UsersController(UserRepository User, IConfiguration configuration) : base(User, configuration)
        {

        }
    }
}
