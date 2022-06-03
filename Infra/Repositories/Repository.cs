using System;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
	public class Repository<Entity> : IRepository<Entity> where Entity : class
	{
        protected readonly UserContext _userContext;
        protected readonly DbSet<Entity> _dbSet;

		public Repository(UserContext userContext)
		{
            _userContext = userContext;
            _dbSet = _userContext.Set<Entity>();
		}

        public bool Add(Entity obj)
        {
            _dbSet.Add(obj);
            return SaveChanges() > 0;
        }

        public bool Delete(Guid id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            return SaveChanges() > 0;
        }

        public void Dispose()
        {
            _userContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<Entity> GetAll() => _dbSet.AsNoTracking();

        public Entity? GetById(Guid id) => _dbSet.Find(id);
        

        public int SaveChanges()
        {
            return _userContext.SaveChanges();
        }

        public bool SoftDelete(Entity obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Entity obj)
        {
            if (obj == null) return false;
            _dbSet.Update(obj);
            return SaveChanges() > 0;
        }
    }
}

