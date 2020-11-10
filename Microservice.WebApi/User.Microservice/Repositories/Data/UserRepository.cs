using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Microservice.Context;
using User.Microservice.Models;

namespace User.Microservice.Repositories.Data
{

    public class UserRepository : GeneralRepository<Users, MyContext>
    {
        public UserRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
