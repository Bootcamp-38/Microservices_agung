using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UserManagement.Context;
using UserManagement.Models;
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

        [HttpPost(nameof(Get))]
        public async Task<string> Get(UserRoleVM userroleVM)
        {
            //var v = await _db.Users.Where(x => x.Email == userroleVM.User_Email).FirstOrDefaultAsync();
            var dbparams = new DynamicParameters();

            dbparams.Add("@User_Email", userroleVM.User_Email, DbType.String);
            var result = await Task.FromResult(_dapper.Get<UserRoleVM>("[dbo].[SP_Login]",
                dbparams, commandType: CommandType.StoredProcedure));

            if (BCrypt.Net.BCrypt.Verify(userroleVM.User_Password, result.User_Password))
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("User_Email", result.User_Email),
                    new Claim("Role_Name", result.Role_Name)
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return "wrong";
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPatch(nameof(ChangePassword))]
        public Task<int> ChangePassword(Users data)
        {
            var dbPara = new DynamicParameters();
            var password = data.Password;
            data.Password = BCrypt.Net.BCrypt.HashPassword(password);
            dbPara.Add("Id", data.Id);
            dbPara.Add("Password", data.Password, DbType.String);

            var updateUser = Task.FromResult(_dapper.Update<int>("[dbo].[SP_Change_Password]",
                            dbPara,
                            commandType: CommandType.StoredProcedure));
            return updateUser;
        }

        [HttpPatch(nameof(Forgot))]
        public async Task<Users> Forgot(Users entity)
        {
            Guid id = Guid.NewGuid();
            string guid = id.ToString();
            entity.Password = BCrypt.Net.BCrypt.HashPassword(guid);
            _myContext.Entry(entity).State = EntityState.Modified;
            await _myContext.SaveChangesAsync();

            MailMessage mm = new MailMessage("agungaliakbar5@gmail.com", entity.Email.ToString());
            mm.Subject = "Reset Your Password ! " + DateTime.Now.ToString();
            mm.Body = string.Format("Hello is your email " + entity.Email.ToString() + " your password is " + guid);
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential nc = new NetworkCredential();
            nc.UserName = "agungaliakbar5@gmail.com";
            nc.Password = "twincell";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Port = 587;
            smtp.Send(mm);

            return entity;
        }

    }
}
