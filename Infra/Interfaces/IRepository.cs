using System;
namespace Infra.Interfaces
{
	public interface IRepository<T> : IDisposable where T : class
	{
		bool Add(T obj);
		bool Update(T obj);
		bool Delete(Guid id);
		bool SoftDelete(T obj);
		T? GetById(Guid id);
		IQueryable<T> GetAll();
		int SaveChanges();
	}
}

