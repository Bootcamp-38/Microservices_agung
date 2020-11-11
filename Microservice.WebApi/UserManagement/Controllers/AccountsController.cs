using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using UserManagement.Context;
using UserManagement.Services;
using UserManagement.ViewModels;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IDapper _dapper;
        public IConfiguration _configuration;
        private readonly MyContext _myContext;


        public AccountsController(IConfiguration configuration, IDapper dapper, MyContext myContext)
        {
            _myContext = myContext;
            _configuration = configuration;
            _dapper = dapper;
        }

        [HttpPost(nameof(Register))]
        public async Task<int> Register(UserRoleVM data)
        {
            var dbparams = new DynamicParameters();

            var password = data.User_Password;
            data.User_Password = BCrypt.Net.BCrypt.HashPassword(password);
            dbparams.Add("FirstName", data.FirstName, DbType.String);
            dbparams.Add("LastName", data.LastName, DbType.String);
            dbparams.Add("Address", data.Address, DbType.String);
            dbparams.Add("BirthDate", data.BirthDate, DbType.Date);
            dbparams.Add("Phone", data.Phone, DbType.String);
            dbparams.Add("User_Email", data.User_Email, DbType.String);
            dbparams.Add("User_Password", data.User_Password, DbType.String);
            dbparams.Add("Role_RoleId", data.Role_RoleId, DbType.Int32);
            var result = await Task.FromResult(_dapper.Insert<int>("[dbo].[SP_Register]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
