using System;
using Domain.Common;

namespace Repository.Repositories.Interfaces
{
	public interface IBaseRepository<T> where T:BaseEntity
	{
		Task CreateAsync(T entity);
		Task EditAsync(T entity);
		Task DeleteAsync(int id);
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetById(int id);
		Task<T> GetAsync(int id);
	}
}

