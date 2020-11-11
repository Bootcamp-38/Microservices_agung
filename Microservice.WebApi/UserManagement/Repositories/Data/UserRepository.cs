using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Context;
using UserManagement.Models;

namespace UserManagement.Repositories.Data
{
    public class UserRepository : GeneralRepository<Users, MyContext>
    {
        public UserRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
