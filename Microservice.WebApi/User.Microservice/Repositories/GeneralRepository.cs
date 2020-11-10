using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using User.Microservice.Bases;
using User.Microservice.Context;
using User.Microservice.Repositories.Interface;

namespace User.Microservice.Repositories
{
    public class GeneralRepository<TEntity, IContext> : IRepository<TEntity>
       where TEntity : class, IEntity
       where IContext : MyContext
    {
        private readonly MyContext _myContext;

        public GeneralRepository(MyContext myContext)
        {
            _myContext = myContext;
        }
        public async Task<TEntity> Delete(int id)
        {
            //var entity = await Get(id);
            var entity = await _myContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }
            _myContext.Set<TEntity>().Remove(entity);
            await _myContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Forgot(TEntity entity)
        {
            Guid id = Guid.NewGuid();
            string guid = id.ToString();
            entity.Password = guid;
            _myContext.Entry(entity).State = EntityState.Modified;
            await _myContext.SaveChangesAsync();

            MailMessage mm = new MailMessage("agungaliakbar5@gmail.com", entity.Email.ToString());
            mm.Subject = "Reset Your Password ! " + DateTime.Now.ToString();
            mm.Body = string.Format("your email " + entity.Email.ToString() + " your password is " + entity.Password.ToString());
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

        public async Task<TEntity> Get(TEntity entity)
        {
            var account = await _myContext.Set<TEntity>().SingleOrDefaultAsync(x => x.Email == entity.Email);
            if (BCrypt.Net.BCrypt.Verify(entity.Password, account.Password))
            {
                return account;
            }
            return account;
            //return await _myContext.Set<TEntity>().SingleOrDefaultAsync(x => x.Email == entity.Email && x.Password == entity.Password);
        }

        public async Task<TEntity> Post(TEntity entity)
        {
            var password = entity.Password;
            entity.Password = BCrypt.Net.BCrypt.HashPassword(password);
            await _myContext.Set<TEntity>().AddAsync(entity);
            await _myContext.SaveChangesAsync();
            return entity;

        }

        public async Task<TEntity> Put(TEntity entity)
        {
            var password = entity.Password;
            entity.Password = BCrypt.Net.BCrypt.HashPassword(password);
            _myContext.Entry(entity).State = EntityState.Modified;
            await _myContext.SaveChangesAsync();
            return entity;

        }
    }
}
