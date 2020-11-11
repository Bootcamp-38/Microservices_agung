using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Context;
using UserManagement.Models;

namespace UserManagement.Repositories.Data
{
    public class RoleRepository : GeneralRepository<Roles, MyContext>
    {
        public RoleRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
