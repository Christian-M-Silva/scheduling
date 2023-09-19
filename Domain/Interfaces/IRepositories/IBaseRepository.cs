using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Get (Guid id);
        Task<T> Post(T entity);
        Task<T> Update(T entity, Guid id);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<T>> GetAll();
    }
}
