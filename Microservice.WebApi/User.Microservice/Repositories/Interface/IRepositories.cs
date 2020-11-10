using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Microservice.Bases;

namespace User.Microservice.Repositories.Interface
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<T> Forgot(T entity);
        //Task<List<T>> Get();
        Task<T> Get(T entity);
        Task<T> Post(T entity);
        Task<T> Put(T entity);
        Task<T> Delete(int id);
        //Task Get<TEntity>(TEntity entity) where TEntity : class, IEntity;
    }
}
