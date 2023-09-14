using Data.Context;
using Domain.Entites;
using Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dbSet;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var result = await _dbSet.SingleOrDefaultAsync(item => item.Id.Equals(id));
                if (result == null)
                {
                    return false;
                }
                _dbSet.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        public async Task<T> Get(Guid id)
        {
            return await _dbSet.SingleOrDefaultAsync(item => item.Id.Equals(id));
        }

        public async Task<T> Post(T entity)
        {
            try
            {
                entity.Id = Guid.NewGuid();
                entity.CreatedAT = DateTime.Now;
                _dbSet.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception erro)
            {

                throw erro;
            }
           

        }

        public async Task<T> Update(T entity, Guid id)
        {
            try
            {
                var result = await _dbSet.SingleOrDefaultAsync(item => item.Id.Equals(id));
                if (result == null)
                {
                    return null;
                }
                entity.UpdateAt= DateTime.Now;
                entity.CreatedAT = result.CreatedAT;
                entity.Id = result.Id;
                _context.Entry(result).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }
    }
}
