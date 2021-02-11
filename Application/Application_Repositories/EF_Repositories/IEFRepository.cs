using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApplicationLayer.Application_Repositories.EF_Repositories
{
	public interface IEFRepository
	{
		Task<List<T>> FindAll<T>() where T : class;
		Task<T> FindById<T>(long id) where T : class;
		Task CreateAsync<T>(T entity) where T : class;
		Task UpdateAsync<T>(T entity) where T : class;
		Task DeleteAsync<T>(T entity) where T : class;
		Task<List<T>> FindAllByLambda<T>(Expression<Func<T, bool>> expression) where T : class;
		T Single<T>(Expression<Func<T, bool>> expression) where T : class;
	}
}
