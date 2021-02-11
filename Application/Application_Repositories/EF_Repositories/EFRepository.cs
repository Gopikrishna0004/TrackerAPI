using DomainLayer.Table_Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Application_Repositories.EF_Repositories
{
    //public class EFRepository : IEFRepository
    //{

    //}

    public class EFRepository<Tracker_Db_Context> : IEFRepository where Tracker_Db_Context : DbContext
    {
		private readonly Tracker_Db_Context _db_Context;

        public EFRepository(Tracker_Db_Context db_Context)
        {
            _db_Context = db_Context;
		}
        
		public async Task CreateAsync<T>(T entity) where T : class
        {
            _db_Context.Set<T>().Add(entity);

            _ = await _db_Context.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            _db_Context.Set<T>().Remove(entity);

            _ = await _db_Context.SaveChangesAsync();
        }

        public async Task<List<T>> FindAll<T>() where T : class
        {
            return await _db_Context.Set<T>().ToListAsync();
        }

        public async Task<T> FindById<T>(long id) where T : class
        {
            return await _db_Context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            _db_Context.Set<T>().Update(entity);

            _ = await _db_Context.SaveChangesAsync();
        }

        public async Task<List<T>> FindAllByLambda<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await _db_Context.Set<T>().Where<T>(expression).ToListAsync<T>();
        }

        public T Single<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return _db_Context.Set<T>().AsQueryable<T>().FirstOrDefault(expression);
        }
    }
}
